using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListWebApi.Domain.Entities;

namespace TodoListWebApi.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllTodosAsync();

        Task<Todo> AddTodoAsync(Todo todo);

        Task ToggleCompletedTodoAsync(Todo todo);

        Task<int> DeleteTodoAsync(int id);
    }
}