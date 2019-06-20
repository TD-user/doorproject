namespace EntitiesDB
{
    public class Door
    {
        public Door()
        {
        }

        public Door(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}
