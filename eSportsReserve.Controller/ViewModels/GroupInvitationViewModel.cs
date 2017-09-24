using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using eSportsReserve.Core.Enum;

namespace eSportsReserve.Controller.ViewModels
{
    public class GroupInvitationViewModel
    {
        [Required]
        [JsonProperty("groupid")]
        public Guid GroupId { get; set; }

        [Required]
        [JsonProperty("contactinfo")]
        public String ContactInfo { get; set; }

        [Required]
        [JsonProperty("contactpreference")]
        public ContactPreference ContactPreference { get; set; }

        [Required]
        [JsonProperty("isaccepted")]
        public Boolean IsAccepted { get; set; }

        [Required]
        [JsonProperty("createdat")]
        public DateTime CreatedAt { get; set; }

     

    }
}
