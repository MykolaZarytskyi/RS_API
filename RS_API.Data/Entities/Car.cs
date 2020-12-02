using RS_API.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RS_API.Data.Entities
{
    public abstract class Car : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Mark { get; set; }

        [Required]
        public string Model { get; set; }
    }
}
