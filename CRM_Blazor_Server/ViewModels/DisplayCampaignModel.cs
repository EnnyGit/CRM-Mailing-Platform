using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Blazor_Server.ViewModels
{
    public class DisplayCampaignModel
    {
        [StringLength(15, ErrorMessage = "Title is too long.")]
        [MinLength(3, ErrorMessage = "Title is too short.")]
        public string Title { get; set; }

        [StringLength(15, ErrorMessage = "Subject is too long.")]
        [MinLength(3, ErrorMessage = "Subject is too short.")]
        public string Subject { get; set; }

        [StringLength(50, ErrorMessage = "PreviewText is too long.")]
        [MinLength(3, ErrorMessage = "PreviewText is too short.")]
        public string PreviewText { get; set; }

        [StringLength(15, ErrorMessage = "Title is too long.")]
        [MinLength(3, ErrorMessage = "Title is too short.")]
        public string FromName { get; set; }

        [EmailAddress]
        public string FromEmail { get; set; }
    }
}
