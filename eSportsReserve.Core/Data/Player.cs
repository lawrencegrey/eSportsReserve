using System;
using System.Collections.Generic;
using System.Text;
using eSportsReserve.Core.Enum;

namespace eSportsReserve.Core.Data
{
    public class Player
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String ContactNo { get; set; }
        public ContactType ContactType { get; set; }
        public ContactPreference ContactPreference { get; set; }

        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }


        public virtual User User { get; set; }
        
    }
}
