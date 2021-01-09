using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Blazor_Server.ViewModels
{
    public class DisplayClientModel
    {
        [Required]
        [StringLength(15, ErrorMessage = "Name is too long.")]
        [MinLength(5, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }
    }
}
