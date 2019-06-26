using System.Linq;
using DBDataProvider;
using EntitiesDB;
namespace DbDataProvider
{
    public class DoorProvider
    {
        private readonly DataContext dataContext;

        public DoorProvider()
        {
            dataContext = new DataContext();
        }

        public Door GetDoorByID(int ID)
        {
            Door door = dataContext.Doors.FirstOrDefault(d => d.ID == ID);
            return door != null ? door : null;
        }

        public Door GetDoorByName(string name)
        {
            Door door = dataContext.Doors.FirstOrDefault(d => d.Name == name);
            return door != null ? door : null;
        }

        public void AddDoor(Door door)
        {
            dataContext.Doors.Add(door);
            dataContext.SaveChanges();
        }

        public void AddDoors(params Door[] door)
        {
            dataContext.Doors.AddRange(door);
            dataContext.SaveChangesAsync();
        }

        public void UpdateDoor(Door door)
        {
            Door doorOld = dataContext.Doors.FirstOrDefault(d => d.Name == door.Name);
            if(doorOld != null)
            {
                doorOld.Name = door.Name;
                dataContext.SaveChanges();
            }
        }

        public void DeleteDoorById(int ID)
        {
            Door doorOld = dataContext.Doors.FirstOrDefault(d => d.ID == ID);
            if (doorOld != null)
            {
                dataContext.Doors.Remove(doorOld);
                dataContext.SaveChanges();
            }
        }

        public void DeleteDoorByName(string Name)
        {
            Door doorOld = dataContext.Doors.FirstOrDefault(d => d.Name == Name);
            if (doorOld != null)
            {
                dataContext.Doors.Remove(doorOld);
                dataContext.SaveChanges();
            }
        }
    }
}
