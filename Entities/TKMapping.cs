using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TKMapping
    {
        public class IJ
        {
            public int I { get; set; }
            public int J { get; set; }
        }

        public Dictionary<string, IJ> Mapping { get; set; } = new Dictionary<string, IJ>();
        public Dictionary<IJ, string> ValidationMap { get; set; } = new Dictionary<IJ, string>();

        public TKMapping()
        {
            Mapping.Add("Id", new IJ() { I = 1, J = 10 });
            Mapping.Add("Brigade", new IJ() { I = 5, J = 1 });
            Mapping.Add("Date", new IJ() { I = 5, J = 12 });
            Mapping.Add("OfficialPerson", new IJ() { I = 7, J = 4 });
            Mapping.Add("OfficialForPrinting", new IJ() { I = 8, J = 4 });
            Mapping.Add("BlockId", new IJ() { I = 11, J = 1 });
            Mapping.Add("CuttingType", new IJ() { I = 11, J = 2 });
            Mapping.Add("AdditionalInfo", new IJ() { I = 11, J = 4 });
            Mapping.Add("Door1", new IJ() { I = 11, J = 6 });
            Mapping.Add("Door2", new IJ() { I = 11, J = 8 });
            Mapping.Add("DoorBox", new IJ() { I = 11, J = 10 });
            Mapping.Add("Hinge1", new IJ() { I = 11, J = 12 });
            Mapping.Add("Hinge2", new IJ() { I = 11, J = 13 });
            Mapping.Add("HingeCount", new IJ() { I = 11, J = 14 });
            Mapping.Add("LockType", new IJ() { I = 11, J = 15 });
            Mapping.Add("InsertingSecret", new IJ() { I = 11, J = 17 });
            Mapping.Add("DoorStep", new IJ() { I = 11, J = 19 });
            Mapping.Add("Note", new IJ() { I = 11, J = 21 });
            Mapping.Add("OrderNumber", new IJ() { I = 11, J = 23 });

            Mapping.Add("TechnoCardValid", new IJ() { I = 1, J = 4 });
            Mapping.Add("BlockValid", new IJ() { I = 10, J = 1 });
            Mapping.Add("OrderValid", new IJ() { I = 10, J = 23 });

            ValidationMap.Add(this.Mapping["TechnoCardValid"], "технологічна карта");
            ValidationMap.Add(this.Mapping["BlockValid"], "блок");
            ValidationMap.Add(this.Mapping["OrderValid"], "номер заказа");
        }
    }
}
