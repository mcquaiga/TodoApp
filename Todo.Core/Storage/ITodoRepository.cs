using System;
using System.Collections.Generic;
using Todo.Core.Models;

namespace Todo.Core.Storage
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(Guid id);
        TodoItem Remove(Guid id);
        void Update(TodoItem item);
    }
}
