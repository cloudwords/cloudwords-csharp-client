using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class SourceLanguage
    {
        public string display { get; set; }
        public string languageCode { get; set; }
        public SourceLanguage()
        {
            display = "";
        }
        public SourceLanguage(string LanguageCode)
        {
            display = "";
            languageCode = LanguageCode;
        }
        public SourceLanguage(string Display, string LanguageCode)
        {
            display = Display;
            languageCode = LanguageCode;
        }
    }
}
