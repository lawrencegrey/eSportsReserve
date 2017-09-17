﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eSportsReserve.Core.Data
{
    public class Group
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Player CaptainId { get; set; }
        public String GroupPass { get; set; }

        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }


    }
}