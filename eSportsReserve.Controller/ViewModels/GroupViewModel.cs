using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using eSportsReserve.Core.Enum;

namespace eSportsReserve.Controller.ViewModels
{
    public class GroupViewModel
    {
        [Required]
        [JsonProperty("name")]
        public String Name { get; set; }

        [Required]
        [JsonProperty("captainid")]
        public Guid CaptainId { get; set; }

        [Required]
        [JsonProperty("grouptype")]
        public GroupType GroupType { get; set; }

        [Required]
        [JsonProperty("createdat")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("createdby")]
        public Boolean CreatedBy { get; set; }

       
        [JsonProperty("updatedat")]
        public DateTime UpdateddAt { get; set; }

        [JsonProperty("updatedby")]
        public Boolean UpdatedBy { get; set; }


    }
}
