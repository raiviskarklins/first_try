using System.ComponentModel.DataAnnotations;

namespace ClickToCall.Web.Models
{
	public class CallViewModel
	{
		[Required(ErrorMessage = "User number required"), Phone]
		public string UserNumber { get; set; }

		[Required(ErrorMessage = "End number required"), Phone]
		public string EndNumber { get; set; }

	}
}