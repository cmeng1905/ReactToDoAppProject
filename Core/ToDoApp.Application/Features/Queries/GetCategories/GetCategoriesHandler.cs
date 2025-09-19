using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Dtos.Category;
using ToDoApp.Domain.Entites;
using ToDoApp.Persistence.Contexts;

namespace ToDoApp.Application.Features.Queries.GetCategories
{
    public class GetCategoriesHandler(ToDoContext _toDoContext, IMapper _mapper) : IRequestHandler<GetCategoriesRequest, GetCategoriesResponse>
    {
        public  async Task<GetCategoriesResponse> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = _toDoContext.Categories.AsQueryable();
            if(request.Id.HasValue)
            {
                categories = categories.Where(c => c.Id == request.Id.Value);
            }
            var mappedCategories = _mapper.Map<List<CategoryDto>>(await categories.ToListAsync());
            return new GetCategoriesResponse
            {
                Categories = mappedCategories
            };
        }
    }
}
