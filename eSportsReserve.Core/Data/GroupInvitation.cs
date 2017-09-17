using eSportsReserve.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSportsReserve.Core.Data
{
    public class GroupInvitation
    {
        public Guid GroupId { get; set; }
        public string ContactInfo { get; set; }
        public ContactPreference ContactPreference { get; set; }
        public Boolean IsAccepted { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Group Group { get; set; }

        
    }
}
