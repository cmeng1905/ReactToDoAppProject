using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Dtos.Category;
using ToDoApp.Application.Dtos.ToDo;
using ToDoApp.Application.Features.Commands.UpdateTodos;
using ToDoApp.Domain.Entites;

namespace ToDoApp.Application.Mappings
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ToDo,ToDoDto>().ForMember(s=>s.CategoryName,opt=>opt.MapFrom(src=>src.Category.Name)).ReverseMap();
            CreateMap<ToDo,UpdateTodoRequest>().ReverseMap();
        }
    }
}
