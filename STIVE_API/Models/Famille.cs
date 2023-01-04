using System.ComponentModel.DataAnnotations;

namespace STIVE_API.Models
{
    public class Famille
    {
        [Key]
        public int IdFamille { get; set; }
        [Required]
        public string LibelleFamille { get; set; }

    }
}
