using API.BaseControllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Features.Queries.GetCategories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        [HttpGet("categories")]
        public async Task<GetCategoriesResponse> GetCategories()
        {
            var response = await Mediator.Send(new GetCategoriesRequest());
            return response;
        }

        [HttpGet("categories/{id}")]
        public async Task<GetCategoriesResponse> GetCategoriesById(int id)
        {
            var response = await Mediator.Send(new GetCategoriesRequest { Id = id });
            return response;
        }
    }
}
