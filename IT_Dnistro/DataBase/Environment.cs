using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class Environment// take with
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public virtual Environment Parent { get; set; }
        public virtual EnvironmentType Type { get; set; }

    }
}