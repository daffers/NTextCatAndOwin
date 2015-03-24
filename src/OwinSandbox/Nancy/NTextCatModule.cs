using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;

namespace NancyTest
{
    public class NTextCatModule : Nancy.NancyModule   
    {
        public NTextCatModule()
        {
            Get["/"] = _ => "hello";
            Post["/detect"] = request =>
            {
                var input = this.Bind<LanguageToDetect>();
                return input.TextToTranslate;
                
            };
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