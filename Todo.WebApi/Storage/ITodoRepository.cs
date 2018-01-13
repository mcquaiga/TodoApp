using System;
using System.Collections.Generic;
using Todo.WebApi.Models;

namespace Todo.WebApi.Storage
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
