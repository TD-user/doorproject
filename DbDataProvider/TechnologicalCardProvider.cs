using DBDataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntitiesDB;
namespace DbDataProvider
{
    public class TechnologicalCardProvider
    {
        private readonly DataContext dataContext;
        public TechnologicalCardProvider()
        {
            dataContext = new DataContext();
        }

        public void AddTC(TechnologicalCard TC)
        {
            dataContext.TechonologicalCards.Add(TC);
            dataContext.SaveChanges();
        }

        public TechnologicalCard GetTcByID(int ID)
        {
            TechnologicalCard technologicalCard = dataContext.TechonologicalCards.FirstOrDefault(tc => tc.ID == ID);
            return technologicalCard != null ? technologicalCard : null;
            //return dataContext.TechonologicalCards.Include(tc => tc.Blocks).ToArray();
        }
    }
}
