using System.Collections.Generic;
using System.Web.Http;
using IoC;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Owin;

namespace WebApi
{
	public class Startup
	{
		public void Configuration(IAppBuilder appBuilder)
		{
			var httpConfiguration = new HttpConfiguration();
			httpConfiguration.MapHttpAttributeRoutes();
			var defaultSettings = new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				Converters = new List<JsonConverter>
				{
					new StringEnumConverter
					{
						CamelCaseText = true
					}
				},
			};
			JsonConvert.DefaultSettings = () => defaultSettings;
			httpConfiguration.Formatters.JsonFormatter.SerializerSettings = defaultSettings;
			var container = UnityInitializerSingleton.GetInstance().Container;
			httpConfiguration.DependencyResolver = new UnityResolver(container);
			SwaggerConfig.Register(httpConfiguration);
			appBuilder.UseWebApi(httpConfiguration);

		}
	}
}