using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Blazor_Server.ViewModels
{
    public class DisplayUserModel
    {
        [Required]
        [StringLength(15, ErrorMessage = "First Name is too long.")]
        [MinLength(5, ErrorMessage = "First Name is too short.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "First Name is too long.")]
        [MinLength(5, ErrorMessage = "First Name is too short.")]
        public string LastName { get; set; }

        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
