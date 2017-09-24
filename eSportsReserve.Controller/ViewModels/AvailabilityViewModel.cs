using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using eSportsReserve.Core.Enum;

namespace eSportsReserve.Controller.ViewModels
{
    public class AvailabilityViewModel
    {
        [Required]
        [JsonProperty("reservationid")]
        public Guid ReservationId { get; set; }

        [Required]
        [JsonProperty("deadline")]
        public DateTime Deadline { get; set; }

        [Required]
        [JsonProperty("groupid")]
        public Guid GroupId { get; set; }

        [Required]
        [JsonProperty("playerid")]
        public Guid PlayerId { get; set; }





    }
}
