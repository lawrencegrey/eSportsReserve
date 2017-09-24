using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSportsReserve.Abstractions.ViewModels
{
    public class ModelStateErrorViewModel
    {
        public ModelStateErrorViewModel()
        {
            Errors = new List<ErrorViewModel>();
        }

        [JsonProperty("errors")]
        public List<ErrorViewModel> Errors { get; set; }
    }
}
