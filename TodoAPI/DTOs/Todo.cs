using System;
using System.ComponentModel.DataAnnotations;

using TodoAPI.Domain.Entities;

namespace TodoAPI.DTOs
{
    public interface CreateTodoDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Description { get; set; }
    }

    public interface UpdateTodoDTO
    {
        [Required]
        public String Title { get; set; }

        [Required]
        public String Description { get; set; }

        public TodoStatus Status { get; set; }
    }
}