using System.ComponentModel.DataAnnotations;

namespace STIVE_API.Models
{
    public class EtatCommandeClient
    {
        [Key]
        public int IdEtatCommandeClient;

        [Required]
        public string LibelleEtatCommandeClient;
    }
}
