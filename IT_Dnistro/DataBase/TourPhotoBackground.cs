using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase
{
    //todo - drop. Use TourPhoto
    //[Obsolete]
    public class TourPhotoBackground
    {
        [Key]
        public int Id { get; set; }
        public string PhotoLink { get; set; }
        public int TourTypeId { get; set; }
        public virtual TourType TourType { get; set; }
    }
}
