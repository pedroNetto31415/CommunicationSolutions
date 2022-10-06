using CommunicationSolutions.Domain.Model.Response;
using System.Threading.Tasks;

namespace CommunicationSolutions.Domain.Interface
{
    public interface IClientRepository
    {
        Task<BalanceResponse> GetBalance(int clientId);
    }
}