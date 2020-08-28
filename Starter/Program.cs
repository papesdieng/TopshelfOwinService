using Topshelf;
using WebApi;

namespace Starter
{
	public class Program
	{
		private const string ServiceName = "TopshelfOwinService";
		public static void Main()
		{
			HostFactory.Run(hostConfigurator =>                                   
			{
				hostConfigurator.Service<WebApiHost>(serviceConfigurator =>                                   
				{
					serviceConfigurator.ConstructUsing(name => new WebApiHost());               
					serviceConfigurator.WhenStarted(webApiHost => webApiHost.Start());                         
					serviceConfigurator.WhenStopped(tc => tc.Stop());                          
				});
				hostConfigurator.RunAsLocalSystem();                                       

				hostConfigurator.SetDescription("Topshelf Owin Service Example");                   
				hostConfigurator.SetDisplayName(ServiceName);                                  
				hostConfigurator.SetServiceName(ServiceName);                                
			});
		}
	}
}
