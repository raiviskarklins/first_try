﻿using System.Configuration;
using Twilio;
using System;

namespace ClickToCall.Web.Services
{
	public interface INotificationService
	{
		void MakePhoneCall(string from, string to, string uriHandler);
	}

	public class NotificationService : INotificationService
	{
		private readonly TwilioRestClient _client;

		public NotificationService()
		{
			var accountSid = ConfigurationManager.AppSettings["TwilioAccountSID"];
			var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
			_client = new TwilioRestClient(accountSid, authToken);
		}

		public void MakePhoneCall(string from, string to, string uriHandler)
		{
			var call = _client.InitiateOutboundCall(from, to, uriHandler);
			if (call.RestException != null)
			{
				Console.WriteLine("RIP");
			}
		}
	}
}