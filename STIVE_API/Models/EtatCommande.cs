using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STIVE_API.Models
{
    public class EtatCommande
    {
        [Key]
        public int IdEtatCommande { get; set; }

        [Required]
        public string NomEtatCommande { get; set; }
    }
}
