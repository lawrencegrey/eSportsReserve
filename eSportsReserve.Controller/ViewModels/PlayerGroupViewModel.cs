using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace eSportsReserve.Controller.ViewModels
{
    public class PlayerGroupViewModel
    {
        [Required]
        [JsonProperty("groupid")]
        public Guid GroupId { get; set; }

        [Required]
        [JsonProperty("playerid")]
        public Guid PlayerId { get; set; }

        [JsonProperty("isinvitationaccepted")]
        public Boolean IsInvitationAccepted { get; set; }

    }
}
