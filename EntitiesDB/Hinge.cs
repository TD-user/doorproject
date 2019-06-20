namespace EntitiesDB
{
    public class Hinge
    {
        public Hinge()
        {
        }

        public Hinge(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}
