using BloodBank_PBD.Models;
using System.Data.Entity;

namespace BloodBank_PBD.Context
{
    public class BloodBankContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
