using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Blazor_Server.ViewModels
{
	public class DisplayContactModel
	{
		[Required]
		[RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
		public string EmailAddress { get; set; }
		[Required]
		[StringLength(15, ErrorMessage = "Name is too long.")]
		[MinLength(1, ErrorMessage = "Name is too short.")]
		public string FirstName { get; set; }
		[Required]
		[StringLength(25, ErrorMessage = "Name is too long.")]
		[MinLength(1, ErrorMessage = "Name is too short.")]

		public string LastName { get; set; }
	}
}
