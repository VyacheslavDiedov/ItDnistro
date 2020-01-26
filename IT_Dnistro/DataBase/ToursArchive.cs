using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class ToursArchive
    {
        [Key]
        public int Id { get; set; }
        public string TourName { get; set; }
        public DateTime TourDate { get; set; }
        public string TourStatus { get; set; }
    }
}