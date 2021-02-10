using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TodoListWebApi.Application.Commands;
using TodoListWebApi.Domain.Entities;
using TodoListWebApi.Domain.Interfaces;

namespace TodoListWebApi.Application.Handlers
{
    public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, Todo>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public UpdateTodoHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<Todo> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = _mapper.Map<Todo>(request);
            await _todoRepository.ToggleCompletedTodoAsync(todo);

            return todo;
        }
    }
}