using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Dtos.ToDo;
using ToDoApp.Domain.Entites;
using ToDoApp.Persistence.Contexts;

namespace ToDoApp.Application.Features.Commands.UpdateTodos
{
    public class UpdateTodoHandler(ToDoContext _toDoContext, IMapper _mapper) : IRequestHandler<UpdateTodoRequest, UpdateTodoResponse>
    {
        public async Task<UpdateTodoResponse> Handle(UpdateTodoRequest request, CancellationToken cancellationToken)
        {
            var todo=await _toDoContext.ToDos.FirstOrDefaultAsync(t => t.Id == request.Id,cancellationToken)?? throw new Exception("Todo not found");
            var category = await _toDoContext.Categories.FirstOrDefaultAsync(s => s.Id == request.CategoryId, cancellationToken) ?? throw new ValidationException("Category not found");

            var updatedTodo = _mapper.Map<ToDo>(request);
            _toDoContext.Entry(todo).CurrentValues.SetValues(updatedTodo);
            var result = await _toDoContext.SaveChangesAsync(cancellationToken) > 0;
            if (result)
                return new UpdateTodoResponse
                {
                    Todos = _mapper.Map<List<ToDoDto>>(await _toDoContext.ToDos.Include(s => s.Category).ToListAsync(cancellationToken))
                };
            else throw new Exception("Failed to update todo");
        }
    }
}
