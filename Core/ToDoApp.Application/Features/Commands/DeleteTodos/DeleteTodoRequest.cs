using MediatR;

namespace ToDoApp.Application.Features.Commands.DeleteTodos
{
    public class DeleteTodoRequest:IRequest<DeleteTodoResponse>
    {
        public int? Id { get; set; }
    }
}