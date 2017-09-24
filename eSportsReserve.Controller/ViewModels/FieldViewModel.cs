using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using eSportsReserve.Core.Enum;

namespace eSportsReserve.Controller.ViewModels
{
    public class FieldViewModel
    {
        [Required]
        [JsonProperty("name")]
        public String Name { get; set; }

        [Required]
        [JsonProperty("capacity")]
        public String Capacity { get; set; }

        [Required]
        [JsonProperty("unittype")]
        public UnitType UnitType { get; set; }

        [Required]
        [JsonProperty("createdate")]
        public DateTime CreatedDate { get; set; }

       
        [JsonProperty("createdby")]
        public Guid CreatedBy { get; set; }

       
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        
        [JsonProperty("updatedby")]
        public Guid UpdatedBy { get; set; }




    }
}
