using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSportsReserve.Abstractions.ViewModels
{
    public class ErrorViewModel
    {
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("error_string")]
        public string ErrorString { get; set; }
    }
}
