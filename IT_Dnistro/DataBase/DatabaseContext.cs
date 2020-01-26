using Microsoft.EntityFrameworkCore;
using System;

namespace DataBase
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<ToursArchive> TourArchives { get; set; }

        //public DatabaseContext()
        //{
        //    Database.EnsureCreated();
        //}
    }
}
