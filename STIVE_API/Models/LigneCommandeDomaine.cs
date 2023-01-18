using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STIVE_API.Models
{
    public class LigneCommandeDomaine
    {
        [Key]
        public int IdLigneCommandeDomaine { get; set; }
        [Required]
        public int QuantiteLigneCommandeDomaine { get; set; }

        [Required]
        public double PrixAchathtLigneCommandeDomaines { get; set; }

        [Required, ForeignKey("articles")]
        public int IdArticle { get; set; }
        [Required, ForeignKey("commandeDomaines")]
        public int IdCommandeDomaine { get; set; }

    }
}
