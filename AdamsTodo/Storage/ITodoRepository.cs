using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdamsTodo.Models;

namespace AdamsTodo.Storage
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
