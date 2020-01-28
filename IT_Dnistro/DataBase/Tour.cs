using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }
        public string TourName { get; set; }
        public int TourTypeId { get; set; }
        public virtual TourType TourType { get; set; }
        public DateTime TourDate { get; set; }
        public int TourLength { get; set; }
    }
}