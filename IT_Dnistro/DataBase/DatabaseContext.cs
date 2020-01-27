using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Tour> Tours { get; set; }
    }
}
