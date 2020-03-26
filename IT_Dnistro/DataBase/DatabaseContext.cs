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
        public DbSet<Participant> Participants { get; set; }
        public DbSet<TourTypeSetting> TourTypeSettings { get; set; }
        public DbSet<EnvironmentType> EnvironmentTypes { get; set; }
        public DbSet<Environment> Environments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TourPhoto>().HasData(
                new TourPhoto[]
                {
                    new TourPhoto {Id = 1, PhotoLink = "foto1.jpg", TourTypeId = 1},
                    new TourPhoto {Id = 2, PhotoLink = "foto2.jpg", TourTypeId = 1},
                    new TourPhoto {Id = 3, PhotoLink = "foto3.jpg", TourTypeId = 1},
                    new TourPhoto {Id = 4, PhotoLink = "foto4.jpg", TourTypeId = 2},
                    new TourPhoto {Id = 5, PhotoLink = "foto5.jpg", TourTypeId = 2},
                    new TourPhoto {Id = 6, PhotoLink = "foto6.jpg", TourTypeId = 2},
                    new TourPhoto {Id = 7, PhotoLink = "photo1.jpg", TourTypeId = 3},
                    new TourPhoto {Id = 8, PhotoLink = "photo2.jpg", TourTypeId = 3},
                    new TourPhoto {Id = 9, PhotoLink = "photo3.jpg", TourTypeId = 3},
                    new TourPhoto {Id = 10, PhotoLink = "photo4.jpg", TourTypeId = 3},
                    new TourPhoto {Id = 11, PhotoLink = "photo5.jpg", TourTypeId = 3}
                });
            modelBuilder.Entity<TourType>().HasData(
                new TourType[]
                {
                    new TourType {Id = 1, TourTypeName="ITDnistro", TourTypeDescription = "For those who like to relax on the river bank"},
                    new TourType {Id = 2, TourTypeName="ITCarpaty", TourTypeDescription = "For those who like to relax in the mountains"},
                    new TourType {Id = 3, TourTypeName="ITScandinavia", TourTypeDescription = "For those who love fjords"}
                });

            modelBuilder.Entity<TourTypeSetting>().HasData(
                new TourTypeSetting[]
                {
                    new TourTypeSetting {Id = 1, BackColor = "", BackgroundImageLink = ""},
                    new TourTypeSetting {Id = 2, BackColor = "", BackgroundImageLink = ""},
                    new TourTypeSetting {Id = 3, BackColor = "", BackgroundImageLink = ""}
                });
        }
    }
}