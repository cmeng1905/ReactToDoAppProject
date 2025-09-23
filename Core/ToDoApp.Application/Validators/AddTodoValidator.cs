using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Features.Commands.AddTodos;

namespace ToDoApp.Application.Validators
{
    public class AddTodoValidator:AbstractValidator<AddTodoRequest>
    {
        public AddTodoValidator()
        {
            RuleFor(s=>s.Title).NotEmpty().WithMessage("Title is required").MaximumLength(100).WithMessage("Title must be less than 100 characters");
            RuleFor(s=>s.Description).NotEmpty().WithMessage("Description is required").MaximumLength(500).WithMessage("Description must be less than 500 characters");
            RuleFor(s => s.CategoryId).GreaterThan(0).WithMessage("Category must be selected!");
        }
    }
}
