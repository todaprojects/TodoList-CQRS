using MediatR;

namespace TodoListWebApi.Application.Commands
{
    public class DeleteTodoCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}