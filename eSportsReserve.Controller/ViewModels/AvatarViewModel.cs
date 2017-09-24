using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using eSportsReserve.Core.Enum;

namespace eSportsReserve.Controller.ViewModels
{
    public class AvatarViewModel
    {
        [Required]
        [JsonProperty("userid")]
        public Guid UserId { get; set; }

        [Required]
        [JsonProperty("imageurl")]
        public String ImageUrl { get; set; }


    }
}
