using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Features.Queries.GetTodos
{
    public class GetTodosRequest:IRequest<GetTodosResponse>
    {
        public int? Id { get; set; }
    }
}
