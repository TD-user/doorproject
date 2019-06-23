using DBDataProvider;
using EntitiesDB;
using System.Linq;

namespace DbDataProvider
{
    public class HingeProvider
    {
        private readonly DataContext dataContext;

        public HingeProvider()
        {
            dataContext = new DataContext();
        }

        public Hinge GetHingeByID(int ID)
        {
            Hinge hinge = dataContext.Hinges.FirstOrDefault(d => d.ID == ID);
            return hinge != null ? hinge : null;
        }

        public Hinge GetHingeByName(string name)
        {
            Hinge hinge = dataContext.Hinges.FirstOrDefault(d => d.Name == name);
            return hinge != null ? hinge : null;
        }

        public void AddHinge(Hinge hinge)
        {
            dataContext.Hinges.Add(hinge);
            dataContext.SaveChanges();
        }

        public void AddHinges(params Hinge[] hinges)
        {
            dataContext.Hinges.AddRange(hinges);
            dataContext.SaveChangesAsync();
        }

        public void UpdateHinge(Hinge hinge)
        {
            Hinge hingeOld = dataContext.Hinges.FirstOrDefault(d => d.Name == hinge.Name);
            if (hingeOld != null)
            {
                hingeOld.Name = hinge.Name;
                dataContext.SaveChanges();
            }
        }

        public void DeleteHingeById(int ID)
        {
            Hinge hingeOld = dataContext.Hinges.FirstOrDefault(d => d.ID == ID);
            if (hingeOld != null)
            {
                dataContext.Hinges.Remove(hingeOld);
                dataContext.SaveChanges();
            }
        }

        public void DeleteHingeByName(string Name)
        {
            Hinge hingeOld = dataContext.Hinges.FirstOrDefault(d => d.Name == Name);
            if (hingeOld != null)
            {
                dataContext.Hinges.Remove(hingeOld);
                dataContext.SaveChanges();
            }
        }
    }
}
