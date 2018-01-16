using Microsoft.EntityFrameworkCore;
using Todo.Core.Models;

namespace Todo.Data.Ef
{
    public sealed class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base((DbContextOptions) options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
