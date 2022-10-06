using CommunicationSolutions.Domain.Interface;
using CommunicationSolutions.Domain.Model.Request;
using CommunicationSolutions.Domain.Model.Response;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationSolutions.Infra.Repositories
{
    public class VoucherCardRepository : BaseRepository, IVoucherCardRepository
    {
        public BalanceResponse GetBalanceByCardId(int cardId)
        {
            BalanceResponse response = new BalanceResponse();

            try
            {
                _connection.Open();

                if (IsConnectionOpen())
                {
                    string query = @"SELECT dbo.fn_GetVoucherUserBalance(@cardId)";

                    double balance = _connection
                                     .Query<double>(query, param: new { cardId }, commandTimeout: 20)
                                     .FirstOrDefault();

                    if (balance != 0)
                    {
                        response.ErrorId = 0;
                        response.Balance = balance;
                        response.Message = "Saldo consultado com sucesso.";

                    }
                    else
                    {
                        response.ErrorId = 500;
                        response.Message = "CardId não encontrado.";
                    }

                }
            }
            catch (Exception e)
            {
                response.Message = "Falha ao consultar o saldo";
                response.ErrorId = 500;
            }
            finally
            {
                CloseConnection();
            }

            return response;
        }
        public CardIdResponse GetCardId(ClientCallRequest clientCallRequest)
        {
            var response = new CardIdResponse();

            try
            {
                _connection.Open();

                if (IsConnectionOpen())
                {
                    string query = @"SELECT 

                                        CardId

                                     FROM VoucherCard vc
                                     INNER JOIN Client c
                                     ON c.ClientId = vc.ClientId

                                     WHERE
                                        c.NationalId = @NationalId AND vc.Password = @Password
                                    ";

                    int cardId = _connection
                                     .Query<int>(
                                            query,
                                            param: new
                                            {
                                                NationalId = clientCallRequest.NationalId,
                                                Password = clientCallRequest.Password
                                            },
                                            commandTimeout: 20
                                      )
                                     .FirstOrDefault();

                    if (cardId != 0)
                    {
                        response.ErrorId = 0;
                        response.CardId =  cardId;
                        response.Message = "CardId consultado com sucesso.";

                    }
                    else
                    {
                        response.ErrorId = 500;
                        response.Message = "cardId não encontrado.";
                    }

                }
            }
            catch (Exception e)
            {
                response.Message = "Falha ao consultar o CardId";
                response.ErrorId = 500;
            }
            finally
            {
                CloseConnection();
            }

            return response;
        }
    }
}
