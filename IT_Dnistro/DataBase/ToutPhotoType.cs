using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class ToutPhotoType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } //General, Background
    }
}