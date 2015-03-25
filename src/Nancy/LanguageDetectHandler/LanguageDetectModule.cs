using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;

namespace LanguageDetectHandler
{
    public class LanguageDetectModule : Nancy.NancyModule
    {
        public LanguageDetectModule()
        {
            Post["/Languages"] = _ =>
            {
                TestInput input = this.Bind();
                return input.ReasonInappropriate;
            };
        }
    }

    public class TestInput
    {
        public string ReportedReviewId;
        public string ReasonInappropriate;
    }
}
