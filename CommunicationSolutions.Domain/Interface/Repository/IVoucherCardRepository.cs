using CommunicationSolutions.Domain.Model.Request;
using CommunicationSolutions.Domain.Model.Response;
using System.Threading.Tasks;

namespace CommunicationSolutions.Domain.Interface.Repository
{
    public interface IVoucherCardRepository
    {
        BalanceResponse GetBalanceByCardId(int cardId);
        CardIdResponse GetCardId(ClientCallRequest clientCallRequest);
    }
}