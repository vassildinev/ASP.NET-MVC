namespace MvcTemplate.Services.Sanitizers
{
    using Contracts;
    using Ganss.XSS;

    public class SanitizerService : ISanitizerService
    {
        private IHtmlSanitizer sanitizer = new HtmlSanitizer();

        public SanitizerService(IHtmlSanitizer sanitizer)
        {
            this.sanitizer = sanitizer;
        }

        public string Sanitize(string html)
        {
            return this.sanitizer.Sanitize(html);
        }
    }
}
