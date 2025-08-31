using System.ComponentModel.DataAnnotations;

namespace WEB_API_DOT_NET.Models.DTO
{
    public class VillaUpdateDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Details { get; set; }
        public string Name { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public int Sqft { get; set; }
        [Required]
        public int Occupancy { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}
