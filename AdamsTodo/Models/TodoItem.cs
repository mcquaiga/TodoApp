using System;
using System.ComponentModel.DataAnnotations;

namespace AdamsTodo.Models
{
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
