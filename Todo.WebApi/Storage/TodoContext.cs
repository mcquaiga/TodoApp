using Microsoft.EntityFrameworkCore;
using Todo.WebApi.Models;

namespace Todo.WebApi.Storage
{
    public sealed class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
