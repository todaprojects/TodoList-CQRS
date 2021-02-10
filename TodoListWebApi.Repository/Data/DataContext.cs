using Microsoft.EntityFrameworkCore;
using TodoListWebApi.Domain.Entities;

namespace TodoListWebApi.Repository.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo() {Id = 1, Title = "Todo No.1"},
                new Todo() {Id = 2, Title = "Todo No.2"},
                new Todo() {Id = 3, Title = "Todo No.3"}
            );
        }
    }
}