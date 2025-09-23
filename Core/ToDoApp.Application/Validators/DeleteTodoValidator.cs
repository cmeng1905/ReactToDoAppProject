using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Features.Commands.DeleteTodos;

namespace ToDoApp.Application.Validators
{
    public class DeleteTodoValidator : AbstractValidator<DeleteTodoRequest>
    {
        public DeleteTodoValidator()
        {
            RuleFor(s => s.Id).NotEmpty().GreaterThan(0).WithMessage("Todo not found.");
        }
    }
}
