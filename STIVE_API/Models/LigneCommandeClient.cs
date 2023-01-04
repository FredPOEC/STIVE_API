using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STIVE_API.Models
{
    public class LigneCommandeClient
    {
        [Key]
        public int IdLigneCommandeClient { get; set; }
        [Required]
        public int QuantiteLigneCommandeClient { get; set; }
        [Required, ForeignKey("articles")]
        public int IdArticle { get; set; }
        [Required, ForeignKey("commandeClients")]
        public int IdCommandeClient { get; set; }

    }
}
