using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoListWebApi.Application.Commands;
using TodoListWebApi.Domain.Interfaces;

namespace TodoListWebApi.Application.Handlers
{
    public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, int>
    {
        private readonly ITodoRepository _todoRepository;

        public DeleteTodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<int> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            return await _todoRepository.DeleteTodoAsync(request.Id);
        }
    }
}