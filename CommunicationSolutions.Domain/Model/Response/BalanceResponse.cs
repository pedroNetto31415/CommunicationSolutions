using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationSolutions.Domain.Model.Response
{
    public class BalanceResponse : BaseResponse
    {
        [JsonProperty("Balance")]
        public double Balance { get; set; }
    }
}
