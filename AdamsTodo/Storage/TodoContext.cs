using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdamsTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace AdamsTodo.Storage
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
