using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Dtos.Category;

namespace ToDoApp.Application.Features.Queries.GetCategories
{
    public class GetCategoriesResponse
    {
        public List<CategoryDto> Categories { get; set; } = [];
    }
}
