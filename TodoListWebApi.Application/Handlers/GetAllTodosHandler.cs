using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoListWebApi.Application.Queries;
using TodoListWebApi.Domain.Entities;
using TodoListWebApi.Domain.Interfaces;

namespace TodoListWebApi.Application.Handlers
{
    public class GetAllTodosHandler : IRequestHandler<GetAllTodosQuery, IEnumerable<Todo>>
    {
        private readonly ITodoRepository _todoRepository;

        public GetAllTodosHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<Todo>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
        {
            return await _todoRepository.GetAllTodosAsync();
        }
    }
}