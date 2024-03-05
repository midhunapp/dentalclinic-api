﻿using System.ComponentModel.DataAnnotations;

namespace dentalclinic_api.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public string? UserRole { get; set; }
    }
}
