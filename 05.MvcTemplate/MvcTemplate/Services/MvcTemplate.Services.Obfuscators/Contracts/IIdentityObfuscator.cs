namespace MvcTemplate.Services.Obfuscators.Contracts
{
    public interface IIdentityObfuscator<TValue>
        where TValue : struct
    {
        TValue DecodeId(string urlId);

        string EncodeId(TValue id);
    }
}
