using System.Collections.Generic;

namespace Laba1.Models
{
    public class Nation : BaseEntity
    {
        public long SeaMilitaryBudget { get; set; }

        public long AmountOfSeaTrups { get; set; }

        public List<Ship> Ships { get; set; }
    }
}