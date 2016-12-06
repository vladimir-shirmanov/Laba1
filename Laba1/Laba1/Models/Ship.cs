using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laba1.Models
{
    public class Ship : BaseEntity
    {
        public string Description { get; set; }

        public ShipType Type { get; set; }

        public Nation Nation { get; set; }
    }
}