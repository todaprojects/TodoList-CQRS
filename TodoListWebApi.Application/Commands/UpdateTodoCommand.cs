using MediatR;
using TodoListWebApi.Domain.Entities;

namespace TodoListWebApi.Application.Commands
{
    public class UpdateTodoCommand : IRequest<Todo>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; } = false;
    }
}