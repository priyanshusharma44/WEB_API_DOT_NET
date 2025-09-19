using System.ComponentModel.DataAnnotations;

namespace WEB_API_MVC.Models.DTO
{
    public class VillaDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Details { get; set; }
        public string Name { get; set; }
        [Required]
        public double Rate { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}
