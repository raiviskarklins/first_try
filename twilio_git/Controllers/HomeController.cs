using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Twilio.TwiML.Mvc;
using ClickToCall.Web.Models;
using ClickToCall.Web.Services;


namespace twilio_git.Controllers
{
	public class HomeController : TwilioController
	{
		private readonly INotificationService _notificationService;

		public HomeController() : this(new NotificationService())
		{
		}

		public HomeController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}

		public ActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Handle POST
		/// </summary>

		[HttpPost]
		public ActionResult Call(CallViewModel callViewModel)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(m => m.Errors)
									   .Select(e => e.ErrorMessage)
									   .ToList();
				var errorMessage = string.Join(". ", errors);
				return Json(new { success = false, message = errorMessage });
			}

			var twilioNumber = ConfigurationManager.AppSettings["TwilioNumber"];
			var uriHandler = GetUri(callViewModel.EndNumber);
			_notificationService.MakePhoneCall(twilioNumber, callViewModel.UserNumber, uriHandler);

			return Json(new { success = true, message = "Incomming call!" });

		}

		private string GetUri(string endNumber)
		{
			var requestUrlScheme = Request.Url.Scheme;
			var domain = ConfigurationManager.AppSettings["TestDomain"];
			var urlAction = Url.Action("Connect", "Call", new { endNumber });

			return $"{requestUrlScheme}://{domain}{urlAction}";
		}

	}
}
