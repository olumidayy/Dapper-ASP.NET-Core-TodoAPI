using System;
using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public String Firstname { get; set; }

        [Required]
        public String Lastname { get; set; }

        [Required]
        public String Email { get; set; }
    }
}