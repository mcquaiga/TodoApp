using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Todo.WebApi.Models;

namespace Todo.WebApi.Storage
{
    public class TodoRepository : ITodoRepository
    {
        private static readonly ConcurrentDictionary<Guid, TodoItem> Todos = new ConcurrentDictionary<Guid, TodoItem>();

        public TodoRepository()
        {
            Add(new TodoItem { Name = "Item 1" });
            Add(new TodoItem { Name = "Item 2" });
            Add(new TodoItem { Name = "Item 3" });
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return Todos.Values;
        }

        public void Add(TodoItem item)
        {
            item.Id = Guid.NewGuid();
            Todos[item.Id] = item;
        }

        public TodoItem Find(Guid id)
        {
            Todos.TryGetValue(id, out var item);
            return item;
        }

        public TodoItem Remove(Guid id)
        {
            Todos.TryGetValue(id, out var item);
            Todos.TryRemove(id, out item);
            return item;
        }

        public void Update(TodoItem item)
        {
            Todos[item.Id] = item;
        }
    }
}