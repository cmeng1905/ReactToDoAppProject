using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Dtos.ToDo;
using ToDoApp.Persistence.Contexts;

namespace ToDoApp.Application.Features.Queries.GetTodos
{
    public class GetTodosHandler(ToDoContext _toDoContext, IMapper _mapper) : IRequestHandler<GetTodosRequest, GetTodosResponse>
    {
        public async Task<GetTodosResponse> Handle(GetTodosRequest request, CancellationToken cancellationToken)
        {
            var todos = _toDoContext.ToDos.Include(s => s.Category).AsQueryable();
            if (request.Id.HasValue)
                todos = todos.Where(t => t.Id == request.Id.Value);
            var mappedTodos = _mapper.Map<List<ToDoDto>>(await todos.ToListAsync(cancellationToken));
            return new GetTodosResponse
            {
                ToDos = mappedTodos
            };
        }
    }
}
