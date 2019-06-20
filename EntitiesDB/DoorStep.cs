namespace EntitiesDB
{
    public class DoorStep
    {
        public DoorStep()
        {
        }

        public DoorStep(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}
