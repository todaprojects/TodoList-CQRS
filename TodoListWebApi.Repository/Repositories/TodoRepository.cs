using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListWebApi.Domain.Entities;
using TodoListWebApi.Domain.Interfaces;

namespace TodoListWebApi.Repository.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DbContext _context;

        public TodoRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> GetAllTodosAsync()
        {
            var todos = await _context.Set<Todo>().ToListAsync();
            return todos;
        }

        public async Task<Todo> AddTodoAsync(Todo todo)
        {
            _context.Set<Todo>().Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task ToggleCompletedTodoAsync(Todo todo)
        {
            _context.Update(todo);
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteTodoAsync(int id)
        {
            var todo = await _context.Set<Todo>().FindAsync(id);
            if (todo == null)
            {
                return 0;
            }

            _context.Set<Todo>().Remove(todo);
            await _context.SaveChangesAsync();
            return todo.Id;
        }
    }
}