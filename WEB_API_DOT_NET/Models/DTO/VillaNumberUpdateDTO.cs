using System.ComponentModel.DataAnnotations;

namespace WEB_API_DOT_NET.Models.DTO
{
    public class VillaNumberUpdateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }

    }
}
