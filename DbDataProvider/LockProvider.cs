using DBDataProvider;
using EntitiesDB;
using System.Linq;

namespace DbDataProvider
{
    public class LockProvider
    {
        private readonly DataContext dataContext;

        public LockProvider()
        {
            dataContext = new DataContext();
        }

        public Lock GetLockByID(int ID)
        {
            Lock Lock = dataContext.Locks.FirstOrDefault(l => l.ID == ID);
            return Lock != null ? Lock : null;
        }

        public Lock GetLockByName(string name)
        {
            Lock Lock = dataContext.Locks.FirstOrDefault(l => l.Name == name);
            return Lock != null ? Lock : null;
        }

        public void AddLock(Lock Lock)
        {
            dataContext.Locks.Add(Lock);
            dataContext.SaveChanges();
        }

        public void AddLocks(params Lock[] locks)
        {
            dataContext.Locks.AddRange(locks);
            dataContext.SaveChangesAsync();
        }

        public void UpdateLock(Lock Lock)
        {
            Lock lockOld = dataContext.Locks.FirstOrDefault(l => l.Name == Lock.Name);
            if (lockOld != null)
            {
                lockOld.Name = Lock.Name;
                dataContext.SaveChanges();
            }
        }

        public void DeleteLockById(int ID)
        {
            Lock lockOld = dataContext.Locks.FirstOrDefault(l => l.ID == ID);
            if (lockOld != null)
            {
                dataContext.Locks.Remove(lockOld);
                dataContext.SaveChanges();
            }
        }

        public void DeleteLockByName(string Name)
        {
            Lock lockOld = dataContext.Locks.FirstOrDefault(l => l.Name == Name);
            if (lockOld != null)
            {
                dataContext.Locks.Remove(lockOld);
                dataContext.SaveChanges();
            }
        }
    }
}
