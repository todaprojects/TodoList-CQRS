using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoListWebApi.Application.Commands;
using TodoListWebApi.Application.Queries;

namespace TodoListWebApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _mediator.Send(new GetAllTodosQuery());
            return Ok(todos);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] AddTodoCommand command)
        {
            var todo = await _mediator.Send(command);
            if (todo == null)
            {
                return BadRequest("Failed saving");
            }

            return Ok(todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodoCommand command)
        {
            var todo = await _mediator.Send(command);
            if (todo == null)
            {
                return BadRequest("Todo item not found");
            }

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] int id)
        {
            var todoId = await _mediator.Send(new DeleteTodoCommand() {Id = id});
            if (todoId == 0)
            {
                return BadRequest("Todo item not found");
            }
            
            return Ok(todoId);
        }
    }
}