using System.ComponentModel.DataAnnotations;

namespace WEB_API_DOT_NET.Models.DTO
{
    public class VillaDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
