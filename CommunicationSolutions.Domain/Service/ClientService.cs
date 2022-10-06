using CommunicationSolutions.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationSolutions.Domain.Service
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }
    }
}
