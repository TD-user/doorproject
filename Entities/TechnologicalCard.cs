using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TechnologicalCard
    {
        public string Id { get; set; } //номер технологічної карти
        public string Date { get; set; } //дата технологічної крати
        public string Brigade { get; set; } //номер бригади
        public string OfficialPerson { get; set; } //відповідальна особа
        public string OfficialForPrinting { get; set; } //відповідальна за друк
        public List<Block> Blocks { get; set; } = new List<Block>(); //колекція блоків в технологічній карті
    }
}
