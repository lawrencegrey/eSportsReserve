using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSportsReserve.Abstractions.ViewModels
{
    public class ApiResponseViewModel<T>
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("execution_time")]
        public string ExecutionTime { get; set; }
    }
}
