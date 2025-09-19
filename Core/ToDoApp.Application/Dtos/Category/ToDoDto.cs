using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Dtos.Category
{
    public class ToDoDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; } = null!;
    }
}
