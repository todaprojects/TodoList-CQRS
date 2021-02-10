using TodoListWebApi.Application.Commands;
using TodoListWebApi.Domain.Entities;

namespace TodoListWebApi.Application.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Todo, AddTodoCommand>().ReverseMap();
            CreateMap<Todo, UpdateTodoCommand>().ReverseMap();
        }
    }
}