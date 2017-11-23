using Ganss.XSS;
using LearningSystem.Services.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Implementations
{
    public class HtmlService : IHtmlService
    {
        private readonly HtmlSanitizer htmlSanitizer;
        public HtmlService()
        {
            this.htmlSanitizer = new HtmlSanitizer();
            this.htmlSanitizer.AllowedAttributes.Add("class");
        }

        public string Sanitize(string HtmlContent)
        => this.htmlSanitizer.Sanitize(HtmlContent);
    }
}
