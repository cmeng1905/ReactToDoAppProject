using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToDoApp.Application.Features.Commands.UpdateTodos
{
    public class UpdateTodoRequest:IRequest<UpdateTodoResponse>
    {
        [NotMapped]
        [JsonIgnore]
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }
    }
}