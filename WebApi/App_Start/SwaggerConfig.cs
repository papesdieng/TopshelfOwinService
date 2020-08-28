using System;
using System.Web.Http;
using System.Xml.XPath;
using WebActivatorEx;
using WebApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApi
{
    public class SwaggerConfig
    {
	    private const string ServiceName = "TopshelfOwinService Web Api";
	    private const string ServiceDescription = "Web Api example with Topshelf and Owin";
	    private const string DeveloperName = "Pape Singane DIENG";
	    private const string DeveloperEmail = "pape-singane.dieng@outlook.com";
        public static void Register(HttpConfiguration httpConfiguration)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

			httpConfiguration
				.EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", ServiceName).Contact(x =>
                        {
	                        x.Name(DeveloperName);
	                        x.Email(DeveloperEmail);
                        })
	                        .Description(ServiceDescription);

						c.PrettyPrint();
						//c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi(c =>
                    {
						c.DocumentTitle(ServiceName);
						c.DisableValidator();
                    });
        }

        private static string GetXmlCommentsPath()
        {
	        throw new NotImplementedException();
        }
    }
}
