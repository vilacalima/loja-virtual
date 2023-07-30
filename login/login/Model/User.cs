﻿using System.ComponentModel.DataAnnotations;

namespace login.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string? Name { get; set; }

        [Required]
        [StringLength(11)]
        public string? Cpf { get; set; }
        
        [Required]
        [StringLength(70)]
        public string? Email { get; set; }
        
        [Required]
        [StringLength(12)]
        public string? Password { get; set; }
    }
}
