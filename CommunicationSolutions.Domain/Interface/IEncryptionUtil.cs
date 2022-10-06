
namespace CommunicationSolutions.Domain.Interface
{
    public interface IEncryptionUtil
    {
        string  ComputeSha256Hash(string rawData);

        string Encrypt(string plainText, string password);
    }
}