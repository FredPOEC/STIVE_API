using System.ComponentModel.DataAnnotations;

namespace STIVE_API.Models
{
    public class Tva
    {
        [Key]
        public int IdTva { get; set; }
        [Required]
        public Double TauxTva { get; set; }
        [Required]
        public string LibelleTVA { get; set; }
        
    }
}
