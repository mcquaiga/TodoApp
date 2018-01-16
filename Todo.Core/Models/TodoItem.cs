using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Core.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
            
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public string Colour { get; set; }

        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset ArchivedDateTime { get; set; }
    }
}
