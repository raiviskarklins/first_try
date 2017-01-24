using System.Configuration;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;
using System.Web.Mvc;

namespace twilio_git.Controllers
{
	public class CallController : TwilioController
	{
		public ActionResult Connect(string endNumber)
		{
			var twilioAuthToken = ConfigurationManager.AppSettings["TwilioAuthToken"];

			var response = new TwilioResponse();
			response
				.Say("Time for some testing! Get ready!")
				.Dial(endNumber);
			//.Hangup();
			return TwiML(response);
		}
	}
}
