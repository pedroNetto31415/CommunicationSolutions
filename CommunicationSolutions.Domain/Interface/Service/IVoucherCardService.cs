using CommunicationSolutions.Domain.Model.Request;
using CommunicationSolutions.Domain.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationSolutions.Domain.Interface.Service
{
    public interface IVoucherCardService
    {
        BalanceResponse GetBalance(ClientCallRequest clientCallRequest);
    }
}
