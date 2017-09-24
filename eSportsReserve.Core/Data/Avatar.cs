using System;
using System.Collections.Generic;
using System.Text;

namespace eSportsReserve.Core.Data
{
    public class Avatar
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public String ImageUrl { get; set; }

        public virtual Guid User { get; set; }
    }
}
