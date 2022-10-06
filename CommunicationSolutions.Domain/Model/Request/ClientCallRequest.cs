using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationSolutions.Domain.Model.Request
{
    public class ClientCallRequest
    {
        public string NationalId { get; set; }
        public string Password { get; set; }
    }
}
