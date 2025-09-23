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
    public class GetTodosHandler(ToDoContext _toDoContext,IMapper _mapper) : IRequestHandler<GetTodosRequest, GetTodosResponse>
    {
        public async Task<GetTodosResponse> Handle(GetTodosRequest request, CancellationToken cancellationToken)
        {
            var todos = await _toDoContext.ToDos.Include(s=>s.Category).ToListAsync(cancellationToken);
            var mappedTodos = _mapper.Map<List<ToDoDto>>(todos);
            return new GetTodosResponse
            {
                ToDos = mappedTodos
            };
        }
    }
}
