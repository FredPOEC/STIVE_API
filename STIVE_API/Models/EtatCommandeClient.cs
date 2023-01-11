using System.ComponentModel.DataAnnotations;

namespace STIVE_API.Models
{
    public class EtatCommandeClient
    {
        [Key]
        public int IdEtatCommandeClient { get; set; }

        [Required]
        public string LibelleEtatCommandeClient { get; set; }
    }
}
    