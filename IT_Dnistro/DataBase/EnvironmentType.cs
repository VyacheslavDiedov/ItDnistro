using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class EnvironmentType
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }//personal, group
    }
}