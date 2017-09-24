using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using eSportsReserve.Core.Enum;

namespace eSportsReserve.Controller.ViewModels
{
    public class ReservationViewModel
    {

        [Required]
        [JsonProperty("groupid")]
        public Guid GroupId { get; set; }

        [Required]
        [JsonProperty("fieldid")]
        public Guid FieldId { get; set; }

        [Required]
        [JsonProperty("event")]
        public Event Event { get; set; }

        [Required]
        [JsonProperty("starttime")]
        public DateTime StartTime { get; set; }

        [Required]
        [JsonProperty("endtime")]
        public DateTime EndTime { get; set; }

        [Required]
        [JsonProperty("groupcost")]
        public Double GroupCost { get; set; }

        [JsonProperty("approved")]
        public Boolean Approved { get; set; }


        [JsonProperty("approveddate")]
        public DateTime ApprovedDate { get; set; }


        [JsonProperty("approvedby")]
        public Guid ApprovedBy { get; set; }

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
