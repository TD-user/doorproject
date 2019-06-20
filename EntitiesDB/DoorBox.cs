namespace EntitiesDB
{
    public class DoorBox
    {
        public DoorBox()
        {
        }

        public DoorBox(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}
