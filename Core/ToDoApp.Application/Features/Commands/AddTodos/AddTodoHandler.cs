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

namespace ToDoApp.Application.Features.Commands.AddTodos
{
    public class AddTodoHandler(ToDoContext _toDoContext, IMapper _mapper) : IRequestHandler<AddTodoRequest, AddTodoResponse>
    {
        public async Task<AddTodoResponse> Handle(AddTodoRequest request, CancellationToken cancellationToken)
        {
            var category = await _toDoContext.Categories.FirstOrDefaultAsync(s => s.Id == request.CategoryId, cancellationToken) ?? throw new ValidationException("Category not found");
            var todo = new ToDo
            {
                Title = request.Title,
                Description = request.Description,
                CategoryId = request.CategoryId,
            };
            await _toDoContext.ToDos.AddAsync(todo, cancellationToken);
            var result = await _toDoContext.SaveChangesAsync(cancellationToken) > 0;
            if (result)
                return new AddTodoResponse
                {
                    Todos = _mapper.Map<List<ToDoDto>>(await _toDoContext.ToDos.Include(s => s.Category).ToListAsync(cancellationToken))
                };
            else throw new Exception("Failed to add todo");
        }
    }
}
