﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eSportsReserve.Core.Data
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Group GroupId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Field FieldId { get; set; }
        public Double GroupCost { get; set; }

        public Boolean Approved { get; set; }
        public User ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }

        public virtual ICollection<Availability> Availabilities { get; set; }
     
    }
}