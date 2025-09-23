using ToDoApp.Application.Dtos.ToDo;

namespace ToDoApp.Application.Features.Commands.DeleteTodos
{
    public class DeleteTodoResponse
    {
        public List<ToDoDto> Todos { get; internal set; }
    }
}