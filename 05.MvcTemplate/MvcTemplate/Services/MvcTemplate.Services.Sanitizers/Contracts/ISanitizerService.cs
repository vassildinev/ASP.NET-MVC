namespace MvcTemplate.Services.Sanitizers.Contracts
{
    public interface ISanitizerService
    {
        string Sanitize(string html);
    }
}
