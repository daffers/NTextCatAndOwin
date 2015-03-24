using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Microsoft.Owin;
using Newtonsoft.Json;
using Owin;

[assembly: OwinStartup(typeof(Katan.Startup1))]

namespace Katan
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.Run(context =>
            {
                string postedText = "empty";

                if (context.Request.Method.ToLowerInvariant() == "POST".ToLowerInvariant())
                {
                    var reader = new StreamReader(context.Request.Body);
                    var whatWasRead = reader.ReadToEnd();
                    var input = JsonConvert.DeserializeObject<LanguageToDetect>(whatWasRead);
                    postedText = input.TextToTranslate;
                }
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("text to translate: " + postedText);
            });


        }
    }

    public class LanguageToDetect
    {
        [JsonProperty(PropertyName = "profileToUse")]
        public string ProfileToUse { get; set; }

        [JsonProperty(PropertyName = "textToTranslate")]
        public string TextToTranslate { get; set; }
    }
}
