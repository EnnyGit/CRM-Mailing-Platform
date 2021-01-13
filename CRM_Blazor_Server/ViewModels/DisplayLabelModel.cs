using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Blazor_Server.ViewModels
{
    public class DisplayLabelModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        [MinLength(3, ErrorMessage = "Name is too short.")]
        public string LabelName { get; set; }
    }
}
