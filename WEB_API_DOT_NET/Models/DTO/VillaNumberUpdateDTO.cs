using System.ComponentModel.DataAnnotations;

namespace WEB_API_DOT_NET.Models.DTO
{
    public class VillaNumberUpdateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VilaID { get; set; }
        public string SpecialDetails { get; set; }

    }
}
