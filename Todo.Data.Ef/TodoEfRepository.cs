﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Todo.Core.Models;
using Todo.Core.Storage;

namespace Todo.Data.Ef
{
    public class TodoEfRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoEfRepository(TodoContext todoContext)
        {
            _context = todoContext;
        }

        public void Add(TodoItem item)
        {
            item.Id = Guid.NewGuid();
            item.CreatedDateTime = DateTimeOffset.UtcNow;

            _context.TodoItems.Add(item);
            _context.SaveChangesAsync();
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems;
        }

        public TodoItem Find(Guid id)
        {
            return _context.TodoItems.SingleOrDefault(m => m.Id == id);            
        }

        public TodoItem Remove(Guid id)
        {
            var todoItem = _context.TodoItems.SingleOrDefault(m => m.Id == id);

            if (todoItem == null)
                return null;

            _context.TodoItems.Remove(todoItem);
            _context.SaveChangesAsync();
            return todoItem;
        }

        public void Update(TodoItem item)
        {
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(item.Id))
                {
                    throw new KeyNotFoundException(item.Id.ToString());
                }
                else
                {
                    throw;
                }
            }
        }

        private bool TodoItemExists(Guid id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}