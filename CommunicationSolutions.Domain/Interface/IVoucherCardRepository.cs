using CommunicationSolutions.Domain.Model.Request;
using CommunicationSolutions.Domain.Model.Response;
using System.Threading.Tasks;

namespace CommunicationSolutions.Domain.Interface
{
    public interface IVoucherCardRepository
    {
        BalanceResponse GetBalanceByCardId(int cardId);
        CardIdResponse GetCardId(ClientCallRequest clientCallRequest); 
    }
}