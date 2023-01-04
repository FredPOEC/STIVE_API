using System.ComponentModel.DataAnnotations;

namespace STIVE_API.Models
{
    public class Fonction
    {
        [Key]
        public int IdFonction { get; set; }
        [Required]
        public string LibelleFonction { get; set; }

    }
}
