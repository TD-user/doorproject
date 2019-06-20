namespace EntitiesDB
{
    public class Lock
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public Lock(){}

        public Lock(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}
