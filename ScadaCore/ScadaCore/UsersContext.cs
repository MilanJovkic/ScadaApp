using System.Data.Entity;

namespace ScadaCore
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base("name=UsersContext")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}