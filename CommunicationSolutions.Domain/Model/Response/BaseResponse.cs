using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationSolutions.Domain.Model.Response
{
    public class BaseResponse
    {
        [JsonProperty(PropertyName = "errorId")]
        public int ErrorId { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        public BaseResponse(int errorId, string message)
        {
            ErrorId = errorId;
            Message = message;
        }
        public BaseResponse()
        {

        }
    }
}
