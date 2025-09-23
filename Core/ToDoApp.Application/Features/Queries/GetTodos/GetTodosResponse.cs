using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Dtos.ToDo;

namespace ToDoApp.Application.Features.Queries.GetTodos
{
    public class GetTodosResponse
    {
        public List<ToDoDto> ToDos { get; set; } = [];
    }
}
