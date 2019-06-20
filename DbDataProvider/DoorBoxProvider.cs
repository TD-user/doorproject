using DBDataProvider;
using EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDataProvider
{
    class DoorBoxProvider
    {
        private readonly DataContext dataContext;

        public DoorBoxProvider()
        {
            dataContext = new DataContext();
        }

        public DoorBox GetDoorBoxByID(int ID)
        {
            DoorBox doorBox = dataContext.DoorBoxes.FirstOrDefault(d => d.ID == ID);
            return doorBox != null ? doorBox : null;
        }

        public DoorBox GetDoorBoxByName(string name)
        {
            DoorBox doorBox = dataContext.DoorBoxes.FirstOrDefault(d => d.Name == name);
            return doorBox != null ? doorBox : null;
        }

        public void AddDoor(DoorBox doorBox)
        {
            dataContext.DoorBoxes.Add(doorBox);
            dataContext.SaveChanges();
        }

        public void AddDoors(params DoorBox[] doorBox)
        {
            dataContext.DoorBoxes.AddRange(doorBox);
            dataContext.SaveChangesAsync();
        }

        public void UpdateDoor(DoorBox doorBox)
        {
            DoorBox doorBoxOld = dataContext.DoorBoxes.FirstOrDefault(d => d.Name == doorBox.Name);
            if (doorBoxOld != null)
            {
                doorBoxOld.Name = doorBox.Name;
                dataContext.SaveChanges();
            }
        }

        public void DeleteDoorBoxById(int ID)
        {
            DoorBox doorBoxOld = dataContext.DoorBoxes.FirstOrDefault(d => d.ID == ID);
            if (doorBoxOld != null)
            {
                dataContext.DoorBoxes.Remove(doorBoxOld);
                dataContext.SaveChanges();
            }
        }

        public void DeleteDoorByName(string Name)
        {
            DoorBox doorBoxOld = dataContext.DoorBoxes.FirstOrDefault(d => d.Name == Name);
            if (doorBoxOld != null)
            {
                dataContext.DoorBoxes.Remove(doorBoxOld);
                dataContext.SaveChanges();
            }
        }
    }
}
