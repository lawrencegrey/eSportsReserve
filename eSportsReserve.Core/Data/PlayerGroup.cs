using System;
using System.Collections.Generic;
using System.Text;

namespace eSportsReserve.Core.Data
{
    public class PlayerGroup
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Guid PlayerId { get; set; }
        public Boolean IsInvitationAccepted { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public virtual Group Group { get; set; }
       
      
    }
}
