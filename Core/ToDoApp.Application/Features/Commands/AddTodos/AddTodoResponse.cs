
using ToDoApp.Application.Dtos.ToDo;

namespace ToDoApp.Application.Features.Commands.AddTodos
{
    public class AddTodoResponse
    {
        public List<ToDoDto> Todos { get;  set; } = [];
    }
}