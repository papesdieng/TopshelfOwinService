using System;
using Common;
using Microsoft.Owin.Hosting;

namespace WebApi
{
	public class WebApiHost
	{
		public static readonly DateTime StartDate;
		
		private readonly string _protocol = ConfigurationHelper.Get("ServiceProtocol", "http");
		private readonly string _hostname = ConfigurationHelper.Get("ServiceHostName", "localhost");
		private readonly string _port = ConfigurationHelper.Get("ServicePort", "60000");

		private IDisposable _webApp;
		static WebApiHost()
		{
			StartDate = DateTime.Now;
		}
		public void Start()
		{
			var fullUrl = $"{_protocol}://{_hostname}:{_port}";
			_webApp = WebApp.Start<Startup>(fullUrl);
		}

		public void Stop()
		{
			_webApp?.Dispose();
		}
	}
}