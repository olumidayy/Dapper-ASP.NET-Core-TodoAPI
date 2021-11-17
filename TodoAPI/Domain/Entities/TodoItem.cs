using System;
using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Domain.Entities
{
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Description { get; set; }

        public TodoStatus Status { get; set; } = TodoStatus.Todo;
    }
}