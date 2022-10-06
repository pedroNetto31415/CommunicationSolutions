namespace CommunicationSolutions.Domain.Interface.Util
{
    public interface IEncryptionUtil
    {
        string ComputeSha256Hash(string rawData);

        string Encrypt(string plainText, string password);
    }
}