using CommunicationSolutions.Domain.Model.Response;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationSolutions.Infra.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public async Task<BalanceResponse> GetBalance(int clientId)
        {
            BalanceResponse response = new BalanceResponse();

            try
            {
                _connection.Open();

                if (IsConnectionOpen())
                {
                    string query = @" SELECT dbo.fn_GetBalance(@ClientId)";

                    double balance = _connection.Query<double>(query, param: new { clientId }, commandTimeout: 15).FirstOrDefault();

                    response.ErrorId = 0;
                    response.Balance = balance;
                }
            }
            catch (Exception e)
            {
                response.Message = "Falha ao obter o saldo";
            }
            finally
            {
                CloseConnection();
            }

            return response;
        }
    }
}
