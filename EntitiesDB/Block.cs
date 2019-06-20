namespace EntitiesDB
{
    public class Block
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Vrizka { get; set; }
        public string AddOns { get; set; }
        public int DoorOneID { get; set; }
        public Door DoorOne { get; set; }
        public Door DoorTwo { get; set; }
        public int? DoorTwoID { get; set; }
        public DoorBox Box { get; set; }
        public int BoxID { get; set; }
        public Hinge HingeOne { get; set; }
        public int HingeOneID { get; set; }
        public Hinge HingeTwo { get; set; }
        public int? HingeTwoID { get; set; }
        public byte CountHinges { get; set; }
        public Lock Lock { get; set; }
        public int LockID { get; set; }
        public string InsertPotai { get; set; }
        public DoorStep Doorstep { get; set; }
        public int DoorstepID { get; set; }
        public string Note { get; set; }
        public string OrderNumber { get; set; }
        public TechonologicalCard TechCard { get; set; }
        public string TechCardID { get; set; }
        public int Status { get; set; }

        public Block() { }
    }
}
