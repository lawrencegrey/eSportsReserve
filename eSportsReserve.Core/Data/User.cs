using System;
using System.Collections.Generic;
using System.Text;

namespace eSportsReserve.Core.Data
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid AvatarId { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
       

        public virtual Avatar Avatar { get; set; }

    }
}
