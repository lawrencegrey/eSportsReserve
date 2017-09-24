using System;
using System.Collections.Generic;
using System.Text;
using eSportsReserve.Core.Enum;

namespace eSportsReserve.Core.Data
{
    public class Group
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Guid CaptainId { get; set; }
        public GroupType GroupType { get; set; }
        //public String GroupPass { get; set; }

        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }

        public virtual Player Player { get; set; }
        public virtual Guid User { get; set; }

        public virtual ICollection<GroupInvitation> GroupInvitations { get; set; }
        public virtual PlayerGroup PlayerGroup { get; set; }
    }
}
