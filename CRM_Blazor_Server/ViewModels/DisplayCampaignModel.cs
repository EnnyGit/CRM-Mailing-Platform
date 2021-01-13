using System.ComponentModel.DataAnnotations;

namespace CRM_Blazor_Server.ViewModels
{
    public class DisplayCampaignModel
    {
        [StringLength(50, ErrorMessage = "Title is too long.")]
        [MinLength(2, ErrorMessage = "Title is too short.")]
        public string Title { get; set; }

        [StringLength(100, ErrorMessage = "Subject is too long.")]
        [MinLength(2, ErrorMessage = "Subject is too short.")]
        public string Subject { get; set; }

        [StringLength(500, ErrorMessage = "Preview text is too long.")]
        [MinLength(2, ErrorMessage = "Preview text is too short.")]
        public string PreviewText { get; set; }

        [StringLength(50, ErrorMessage = "From name is too long.")]
        [MinLength(2, ErrorMessage = "From name is too short.")]
        public string FromName { get; set; }

        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        public string FromEmail { get; set; }
    }
}