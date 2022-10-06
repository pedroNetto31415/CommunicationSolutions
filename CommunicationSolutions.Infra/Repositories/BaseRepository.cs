using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CommunicationSolutions.Infra.Repositories
{
    public class BaseRepository
    {
        public IDbConnection _connection;
        public BaseRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            _connection = new Database.Connection.Database().GetConnection("user_gestao", "BACKDEV");
        }

        public void OpenIfClosed()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public bool IsConnectionOpen()
        {
            return _connection != null && _connection.State == System.Data.ConnectionState.Open;
        }

        public void CloseConnection()
        {
            try
            {
                if (IsConnectionOpen())
                {
                    _connection.Close();
                }
            }
            catch
            {
                return;
            }
        }
    }
}
