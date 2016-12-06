using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laba1.Models
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime BornDate { get; set; }

        public string Biography { get; set; }

        public Nation Nation { get; set; }
    }
}