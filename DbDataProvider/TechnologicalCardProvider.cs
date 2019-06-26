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
            dataContext.SaveChangesAsync();
        }

        public TechnologicalCard GetTcByID(int ID)
        {
            TechnologicalCard technologicalCard = dataContext.TechonologicalCards.Include(tc => tc.Blocks).FirstOrDefault(tc => tc.ID == ID);
            return technologicalCard != null ? technologicalCard : null;
        }

        public TechnologicalCard GetTcByCardNumber(string CardNumber)
        {
            TechnologicalCard technologicalCard = dataContext.TechonologicalCards.Include(tc => tc.Blocks).FirstOrDefault(tc => tc.TechCardNumber == CardNumber);
            return technologicalCard != null ? technologicalCard : null;
        }

        public void DeleteTcByID(int ID)
        {
            TechnologicalCard technologicalCard = dataContext.TechonologicalCards.FirstOrDefault(tc => tc.ID == ID);
            if (technologicalCard != null)
            {
                dataContext.TechonologicalCards.Remove(technologicalCard);
                dataContext.SaveChanges();
            }
        }

        public void DeleteTcByID(string CardNumber)
        {
            TechnologicalCard technologicalCard = dataContext.TechonologicalCards.FirstOrDefault(tc => tc.TechCardNumber == CardNumber);
            if (technologicalCard != null)
            {
                dataContext.TechonologicalCards.Remove(technologicalCard);
                dataContext.SaveChanges();
            }
        }

        public void UpdateTcByID(TechnologicalCard card)
        {
            TechnologicalCard technologicalCard = dataContext.TechonologicalCards.FirstOrDefault(tc => tc.ID == card.ID || tc.TechCardNumber == card.TechCardNumber);
            if (technologicalCard != null)
            {
                technologicalCard.TechCardNumber = card.TechCardNumber;
                technologicalCard.Responsible = card.Responsible;
                technologicalCard.ResponsibleForPrint = card.ResponsibleForPrint;
                technologicalCard.DateUpdated = DateTime.UtcNow;
                dataContext.SaveChanges();
            }
        }
    }
}
