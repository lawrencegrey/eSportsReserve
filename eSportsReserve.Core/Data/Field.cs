﻿using System;
using System.Collections.Generic;
using System.Text;
using eSportsReserve.Core.Enum;

namespace eSportsReserve.Core.Data
{
    public class Field
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public int Capacity { get; set; }
        public UnitType UnitType { get; set; }

        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }
}
