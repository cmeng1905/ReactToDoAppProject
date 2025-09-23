using API.BaseControllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
