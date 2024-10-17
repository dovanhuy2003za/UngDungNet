﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
