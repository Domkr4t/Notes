﻿using System.ComponentModel.DataAnnotations;

namespace Notes.Identity.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        public string ReturnUrl { get; set; } = default!;   
    }
}
