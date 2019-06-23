using DBDataProvider;
using EntitiesDB;
using System.Linq;

namespace DbDataProvider
{
    public class DoorStepProvider
    {
        private readonly DataContext dataContext;

        public DoorStepProvider()
        {
            dataContext = new DataContext();
        }

        public DoorStep GetDoorStepByID(int ID)
        {
            DoorStep doorStep = dataContext.DoorSteps.FirstOrDefault(d => d.ID == ID);
            return doorStep != null ? doorStep : null;
        }

        public DoorStep GetDoorStepByName(string name)
        {
            DoorStep doorStep = dataContext.DoorSteps.FirstOrDefault(d => d.Name == name);
            return doorStep != null ? doorStep : null;
        }

        public void AddDoorStep(DoorStep doorStep)
        {
            dataContext.DoorSteps.Add(doorStep);
            dataContext.SaveChanges();
        }

        public void AddDoorSteps(params DoorStep[] doorSteps)
        {
            dataContext.DoorSteps.AddRange(doorSteps);
            dataContext.SaveChangesAsync();
        }

        public void UpdateDoorStep(DoorStep doorStep)
        {
            DoorStep doorStepOld = dataContext.DoorSteps.FirstOrDefault(d => d.Name == doorStep.Name);
            if (doorStepOld != null)
            {
                doorStepOld.Name = doorStep.Name;
                dataContext.SaveChanges();
            }
        }

        public void DeleteDoorStepById(int ID)
        {
            DoorStep doorStepOld = dataContext.DoorSteps.FirstOrDefault(d => d.ID == ID);
            if (doorStepOld != null)
            {
                dataContext.DoorSteps.Remove(doorStepOld);
                dataContext.SaveChanges();
            }
        }

        public void DeleteDoorStepByName(string Name)
        {
            DoorStep doorStepOld = dataContext.DoorSteps.FirstOrDefault(d => d.Name == Name);
            if (doorStepOld != null)
            {
                dataContext.DoorSteps.Remove(doorStepOld);
                dataContext.SaveChanges();
            }
        }
    }
}
