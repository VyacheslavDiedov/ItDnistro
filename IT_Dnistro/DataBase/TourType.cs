using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class TourType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string TourTypeName { get; set; }
        public string TourTypeDescription { get; set; }
        public int Amount { get; set; }
        [Required]
        public DateTime TourDateFrom { get; set; }
        [Required]
        public DateTime TourDateTo { get; set; }
    }

    //todo Add to db context
    public class TourTypeSettings
    {
        public int Id { get; set; }
        public virtual TourType Type { get; set; }
        public string BackColor { get; set; }
        public string BackgroundImageLink { get; set; }
    }

    //todo Add to db context
    public class EnvironmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }//personal, group
    }

    //todo Add to db context
    public class Environment// take with
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Environment Parent { get; set; }
        public virtual EnvironmentType Type { get; set; }

    }
}