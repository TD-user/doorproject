using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntitiesDB
{
    public class TechnologicalCard
    {
        public int ID { get; set; }
        [Required]
        public string TechCardNumber { get; set; }
        [Required]
        public string Responsible { get; set; }
        [Required]
        public string ResponsibleForPrint { get; set; }
        [Column("DateCreated", TypeName = "DateTime2")]
        public DateTime? DateCreated { get; set; } = DateTime.UtcNow;
        [Column("DateUpdated", TypeName = "DateTime2")]
        public DateTime? DateUpdated { get; set; } = DateTime.UtcNow;

        public ICollection<Block> Blocks { get; set; }

        public TechnologicalCard() {
            Blocks = new List<Block>();
        }
    }
}
