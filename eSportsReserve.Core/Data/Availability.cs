﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eSportsReserve.Core.Data
{
    public class Availability
    {
        public Guid Id { get; set; }
        public Reservation ReservationId { get; set; }
        public DateTime Deadline { get; set; }
        public Player PlayerID { get; set; }
        public Boolean Available { get; set; }

        public virtual ICollection<Player> Players { get; set; }
      
    }
}
