using MediatR;
using TodoListWebApi.Domain.Entities;

namespace TodoListWebApi.Application.Commands
{
    public class AddTodoCommand : IRequest<Todo>
    {
        public string Title { get; set; }
    }
}