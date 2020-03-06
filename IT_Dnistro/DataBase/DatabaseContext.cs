using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
//using IT_Dnistro.Models;

namespace DataBase
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourType> TourTypes { get; set; }
        public DbSet<UserTour> UserTours { get; set; }
        public DbSet<UserAdditionalInfo> UserAdditionalInfos { get; set; }
        public DbSet<TourPhoto> TourPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TourPhoto>().HasData(
                new TourPhoto[]
                {
                    new TourPhoto {Id = 1, PhotoLink="photo1.jpg", TourTypeId = 1},
                    new TourPhoto {Id = 2, PhotoLink="photo2.jpg", TourTypeId = 1},
                    new TourPhoto {Id = 3, PhotoLink="photo3.jpg", TourTypeId = 1},
                    new TourPhoto {Id = 4, PhotoLink="photo4.jpg", TourTypeId = 1},
                    new TourPhoto {Id = 5, PhotoLink="photo5.jpg", TourTypeId = 1}
                });
            modelBuilder.Entity<TourType>().HasData(
                new TourType[]
                {
                    new TourType {Id = 1, TourTypeName="Dnistro", TourTypeDescription = "For those who like to relax on the river bank"},
                    new TourType {Id = 2, TourTypeName="Carpaty", TourTypeDescription = "For those who like to relax in the mountains"},
                    new TourType {Id = 3, TourTypeName="Scandinadia", TourTypeDescription = "For those who love fjords"}
                });
        }
    }
}