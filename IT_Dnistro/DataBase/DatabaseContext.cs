using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
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
        public DbSet<TourPhotoBackground> TourPhotoBackgrounds { get; set; }

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
                    new TourType {Id = 1, TourTypeName="IT DnistrO", TourTypeDescription = "In My Core",TourDateFrom = DateTime.Now.AddDays(7), TourDateTo = DateTime.Now.AddDays(10)},
                    new TourType {Id = 2, TourTypeName="IT Carpaty", TourTypeDescription = "Pass with little losses",TourDateFrom = DateTime.Now.AddDays(10), TourDateTo = DateTime.Now.AddDays(12)},
                    new TourType {Id = 3, TourTypeName="IT Scandinavia", TourTypeDescription = "Move Your Drive",TourDateFrom = DateTime.Now.AddDays(8), TourDateTo = DateTime.Now.AddDays(15)}
                });
            modelBuilder.Entity<TourPhotoBackground>().HasData(
                new TourPhotoBackground[]
                {
                    new TourPhotoBackground {Id = 1, PhotoLink = "photo1.png", TourTypeId = 1},
                    new TourPhotoBackground {Id = 2, PhotoLink = "photo2.png", TourTypeId = 1},
                    new TourPhotoBackground {Id = 3, PhotoLink = "photo3.png", TourTypeId = 1},
                    new TourPhotoBackground {Id = 4, PhotoLink = "photo4.jpg", TourTypeId = 2},
                    new TourPhotoBackground {Id = 5, PhotoLink = "photo5.png", TourTypeId = 2},
                    new TourPhotoBackground {Id = 6, PhotoLink = "photo6.png", TourTypeId = 2},
                    new TourPhotoBackground {Id = 7, PhotoLink = "photo7.png", TourTypeId = 3},
                    new TourPhotoBackground {Id = 8, PhotoLink = "photo8.png", TourTypeId = 3},
                    new TourPhotoBackground {Id = 9, PhotoLink = "photo9.png", TourTypeId = 3}
                });

            //TourTypeSettings
        }
    }
}