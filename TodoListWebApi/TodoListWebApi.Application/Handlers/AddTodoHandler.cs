using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TodoListWebApi.Application.Commands;
using TodoListWebApi.Domain.Entities;
using TodoListWebApi.Domain.Interfaces;

namespace TodoListWebApi.Application.Handlers
{
    public class AddTodoHandler : IRequestHandler<AddTodoCommand, Todo>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public AddTodoHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<Todo> Handle(AddTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = _mapper.Map<Todo>(request);
            
            return await _todoRepository.AddTodoAsync(todo);
        }
    }
}