using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STIVE_API.Models
{
    public class CommandeClient
    {
        [Key]
        public int IdCommandeClient { get; set; }

        [Required, ForeignKey("clients")]
        public int IdClient { get; set; }

        [Required]
        public string DateCommandeClient { get; set; }

        [Required, ForeignKey("etatsCommandeClients")]
        public int IdEtatCommandeClient { get; set; }

    }
}
