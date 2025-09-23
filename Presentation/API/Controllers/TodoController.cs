using API.BaseControllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Features.Commands.AddTodos;
using ToDoApp.Application.Features.Commands.DeleteTodos;
using ToDoApp.Application.Features.Commands.UpdateTodos;
using ToDoApp.Application.Features.Queries.GetCategories;
using ToDoApp.Application.Features.Queries.GetTodos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : CustomBaseController
    {
        [HttpGet("todos")]
        public async Task<GetTodosResponse> GetTodos()
        {
            var response = await Mediator.Send(new GetTodosRequest());
            return response;
        }

        [HttpGet("todos/{id}")]
        public async Task<GetTodosResponse> GetTodosById(int id)
        {
            var response = await Mediator.Send(new GetTodosRequest { Id = id });
            return response;
        }

        [HttpPost("add-todo")]
        public async Task<IActionResult> AddTodo(AddTodoRequest request)
        {
            var response = await Mediator.Send(request);
            return CreatedAtAction(nameof(GetTodos), response.Todos);
        }

        [HttpDelete("delete-todo/{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var response = await Mediator.Send(new DeleteTodoRequest { Id = id });
            return CreatedAtAction(nameof(GetTodos), response.Todos);
        }

        [HttpPut("update-todo/{id}")]
        public async Task<IActionResult> UpdateTodo(int id,UpdateTodoRequest request)
        {
            request.Id = id;
            var response = await Mediator.Send(request);
            return CreatedAtAction(nameof(GetTodos), response.Todos);
        }
    }
}
