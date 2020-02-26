using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace DataBase
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourType> TourTypes { get; set; }
        public DbSet<UserTour> UserTours { get; set; }
        public DbSet<UserAdditionalInfo> UserAdditionalInfos { get; set; }
        public DbSet<TourPhoto> TourPhotos { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}