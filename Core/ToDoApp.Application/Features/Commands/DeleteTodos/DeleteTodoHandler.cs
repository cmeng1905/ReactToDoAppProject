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

namespace ToDoApp.Application.Features.Commands.DeleteTodos
{
    public class DeleteTodoHandler(ToDoContext _toDoContext, IMapper _mapper) : IRequestHandler<DeleteTodoRequest, DeleteTodoResponse>
    {
        public async Task<DeleteTodoResponse> Handle(DeleteTodoRequest request, CancellationToken cancellationToken)
        {
            var todo = await _toDoContext.ToDos.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken) ?? throw new Exception("Todo not found");
            _toDoContext.ToDos.Remove(todo);
            var result = await _toDoContext.SaveChangesAsync(cancellationToken) > 0;
            if (result)
                return new DeleteTodoResponse
                {
                    Todos = _mapper.Map<List<ToDoDto>>(await _toDoContext.ToDos.Include(s => s.Category).ToListAsync(cancellationToken))
                };
            else throw new Exception("Failed to delete todo");

        }
    }
}
