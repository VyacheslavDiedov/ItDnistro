using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase
{
    public class TourPhoto
    {
        [Key]
        public int Id { get; set; }
        public string PhotoLink { get; set; }
        public int TourTypeId { get; set; }
        public virtual TourType TourType { get; set; }
        //todo add ToutPhotoType property
    }

    //todo - use this
    public class ToutPhotoType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } //General, Background
    }
}
