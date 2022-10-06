using CommunicationSolutions.Domain.Interface;
using CommunicationSolutions.Domain.Model.Request;
using CommunicationSolutions.Domain.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationSolutions.Domain.Service
{
    public class VoucherCardService : IVoucherCardService
    {
        private readonly IVoucherCardRepository _voucherCardRepository;
        private readonly IEncryptionUtil _encryptionUtil;

        public VoucherCardService(IVoucherCardRepository voucherCardRepository,
                                    IEncryptionUtil encryptionUtil)
        {
            _voucherCardRepository = voucherCardRepository;
            _encryptionUtil = encryptionUtil;
        }

        public BalanceResponse GetBalance(ClientCallRequest clientCallRequest)
        {
            var balanceReponse = new BalanceResponse();

            clientCallRequest.Password = _encryptionUtil.ComputeSha256Hash(clientCallRequest.Password); 

            var cardIdResponse = _voucherCardRepository.GetCardId(clientCallRequest);

            if (cardIdResponse.ErrorId == 0)
            {
                balanceReponse = _voucherCardRepository.GetBalanceByCardId(cardIdResponse.CardId);
                return balanceReponse;
            }

            balanceReponse.ErrorId = cardIdResponse.ErrorId;
            balanceReponse.Message = cardIdResponse.Message;

            return balanceReponse; 
        }
    }
}
