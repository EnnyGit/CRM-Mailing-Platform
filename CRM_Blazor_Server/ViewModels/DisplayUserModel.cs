﻿using System.ComponentModel.DataAnnotations;

namespace CRM_Blazor_Server.ViewModels
{
    public class DisplayUserModel
    {
        [Required]
        [StringLength(15, ErrorMessage = "First Name is too long.")]
        [MinLength(3, ErrorMessage = "First Name is too short.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "First Name is too long.")]
        [MinLength(3, ErrorMessage = "First Name is too short.")]
        public string LastName { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "password is too short.")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}