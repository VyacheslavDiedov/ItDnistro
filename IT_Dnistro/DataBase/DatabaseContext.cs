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
        public DbSet<TourType> TourTypes { get; set; }
        public DbSet<UserTour> UserTours { get; set; }
        public DbSet<UserAdditionalInfo> UserAdditionalInfos { get; set; }
        public DbSet<TourPhoto> TourPhotos { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<ToutPhotoType> ToutPhotoTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TourPhoto>().HasData(
                new TourPhoto[]
                {
                    new TourPhoto {Id = 1, PhotoLink = "foto1.jpg", TourTypeId = 1, ToutPhotoTypeId = 1},
                    new TourPhoto {Id = 2, PhotoLink = "foto2.jpg", TourTypeId = 1, ToutPhotoTypeId = 1},
                    new TourPhoto {Id = 3, PhotoLink = "foto3.jpg", TourTypeId = 1, ToutPhotoTypeId = 1},
                    new TourPhoto {Id = 4, PhotoLink = "foto4.jpg", TourTypeId = 2, ToutPhotoTypeId = 1},
                    new TourPhoto {Id = 5, PhotoLink = "foto5.jpg", TourTypeId = 2, ToutPhotoTypeId = 1},
                    new TourPhoto {Id = 6, PhotoLink = "foto6.jpg", TourTypeId = 2, ToutPhotoTypeId = 1},
                    new TourPhoto {Id = 7, PhotoLink = "foto7.jpg", TourTypeId = 3, ToutPhotoTypeId = 1},
                    new TourPhoto {Id = 8, PhotoLink = "foto8.jpg", TourTypeId = 3, ToutPhotoTypeId = 1},
                    new TourPhoto {Id = 9, PhotoLink = "foto9.jpg", TourTypeId = 3, ToutPhotoTypeId = 1},
                    new TourPhoto {Id = 10, PhotoLink = "foto10.jpg", TourTypeId = 3, ToutPhotoTypeId = 1},
                    new TourPhoto {Id = 11, PhotoLink = "photo1.png", TourTypeId = 1, ToutPhotoTypeId = 2},
                    new TourPhoto {Id = 12, PhotoLink = "photo2.png", TourTypeId = 1, ToutPhotoTypeId = 2},
                    new TourPhoto {Id = 13, PhotoLink = "photo3.png", TourTypeId = 1, ToutPhotoTypeId = 2},
                    new TourPhoto {Id = 14, PhotoLink = "photo4.jpg", TourTypeId = 2, ToutPhotoTypeId = 2},
                    new TourPhoto {Id = 15, PhotoLink = "photo5.png", TourTypeId = 2, ToutPhotoTypeId = 2},
                    new TourPhoto {Id = 16, PhotoLink = "photo6.png", TourTypeId = 2, ToutPhotoTypeId = 2},
                    new TourPhoto {Id = 17, PhotoLink = "photo7.png", TourTypeId = 3, ToutPhotoTypeId = 2},
                    new TourPhoto {Id = 18, PhotoLink = "photo8.png", TourTypeId = 3, ToutPhotoTypeId = 2},
                    new TourPhoto {Id = 19, PhotoLink = "photo9.png", TourTypeId = 3, ToutPhotoTypeId = 2}
                });
            modelBuilder.Entity<TourType>().HasData(
                new TourType[]
                {
                    new TourType {Id = 1, TourTypeName="IT DnistrO", TourTypeTagName = "In My Core",TourDateFrom = DateTime.Now.AddDays(7), TourDateTo = DateTime.Now.AddDays(10), TourTypeDescription = "Вінницька IT Академія відкриває для всіх бажаючих простори рідного регіону. " +
                                                                                                                                                                                                         "Ми підготували для вас цікаву і насичену програму. Беріть з собою друзів і гайда підкорювати нові «вершини»! " +
                                                                                                                                                                                                         "Свіже повітря, захоплюючі пейзажі, гарна компанія - все для любителів активного відпочинку. Ми побачимо краєвиди, від яких точно перехопить подих. " +
                                                                                                                                                                                                         "А вашим фотографіям  будуть заздрити всі знайомі. Пізнаємо рідний край,  проникаємось любов'ю до нього ;-) у приємній дружній компанії."},
                    new TourType {Id = 2, TourTypeName="IT Carpaty", TourTypeTagName = "Pass with little losses",TourDateFrom = DateTime.Now.AddDays(10), TourDateTo = DateTime.Now.AddDays(12), TourTypeDescription = "Вінницька IT Академія відкриває для всіх бажаючих простори рідного регіону. " +
                                                                                                                                                                                                                       "Ми підготували для вас цікаву і насичену програму. Беріть з собою друзів і гайда підкорювати нові «вершини»! " +
                                                                                                                                                                                                                       "Свіже повітря, захоплюючі пейзажі, гарна компанія - все для любителів активного відпочинку. Ми побачимо краєвиди, від яких точно перехопить подих. " +
                                                                                                                                                                                                                       "А вашим фотографіям  будуть заздрити всі знайомі. Пізнаємо рідний край,  проникаємось любов'ю до нього ;-) у приємній дружній компанії."},
                    new TourType {Id = 3, TourTypeName="IT Scandinavia", TourTypeTagName = "Move Your Drive",TourDateFrom = DateTime.Now.AddDays(8), TourDateTo = DateTime.Now.AddDays(15), TourTypeDescription = "Вінницька IT Академія відкриває для всіх бажаючих простори рідного регіону. " +
                                                                                                                                                                                                                  "Ми підготували для вас цікаву і насичену програму. Беріть з собою друзів і гайда підкорювати нові «вершини»! " +
                                                                                                                                                                                                                  "Свіже повітря, захоплюючі пейзажі, гарна компанія - все для любителів активного відпочинку. Ми побачимо краєвиди, від яких точно перехопить подих. " +
                                                                                                                                                                                                                  "А вашим фотографіям  будуть заздрити всі знайомі. Пізнаємо рідний край,  проникаємось любов'ю до нього ;-) у приємній дружній компанії."}
                });
            modelBuilder.Entity<ToutPhotoType>().HasData(
                new ToutPhotoType[]
                {
                    new ToutPhotoType {Id = 1, Name = "General"},
                    new ToutPhotoType {Id = 2, Name = "Background"}
                });

        }
    }
}