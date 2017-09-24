using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using eSportsReserve.Core.Enum;


namespace eSportsReserve.Controller.ViewModels
{
    public class PlayerViewModel
    {
        [Required]
        [JsonProperty("userid")]
        public Guid UserId { get; set; }

        [Required]
        [JsonProperty("firstname")]
        public String Firstname { get; set; }

       
        [JsonProperty("middlename")]
        public String MiddleName { get; set; }

        [Required]
        [JsonProperty("lastname")]
        public String LastName { get; set; }

        [Required]
        [JsonProperty("email")]
        public String Email { get; set; }

        [Required]
        [JsonProperty("sex")]
        public String Sex { get; set; }

        [Required]
        [JsonProperty("dob")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [JsonProperty("contactpreference")]
        public ContactPreference ContactPerference { get; set; }

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
