using System;
using System.Collections.Generic;

namespace EntitiesDB
{
    public class TechonologicalCard
    {
        public int ID { get; set; }
        public string TechCardNumber { get; set; }
        public string Responsible { get; set; }
        public string ResponsibleForPrint { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public ICollection<Block> Blocks { get; set; }

        public TechonologicalCard() {
            Blocks = new List<Block>();
        }
    }
}
