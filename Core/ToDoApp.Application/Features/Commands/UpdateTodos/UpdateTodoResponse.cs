using ToDoApp.Application.Dtos.ToDo;

namespace ToDoApp.Application.Features.Commands.UpdateTodos
{
    public class UpdateTodoResponse
    {
        public List<ToDoDto> Todos { get;  set; }
    }
}