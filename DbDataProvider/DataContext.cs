using System.Data.Entity;
using EntitiesDB;
namespace DBDataProvider
{
    public class DataContext : DbContext
    {
        public DataContext() :base("DataContext") { }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<DoorBox> DoorBoxes { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<DoorStep> DoorSteps { get; set; }
        public DbSet<Hinge> Hinges { get; set; }
        public DbSet<Lock> Locks { get; set; }
        public DbSet<TechonologicalCard> TechonologicalCards { get; set; }
    }
}
