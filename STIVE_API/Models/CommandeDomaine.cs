using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STIVE_API.Models
{
    public class CommandeDomaine
    {
        [Key]
        public int IdCommandeDomaine { get; set; }
        [Required, ForeignKey("domaines")]
        public int IdDomaine { get; set; }
        [Required]
        public string DateCommandeDomaine { get; set; }
        [Required]
        public string EtatCommandeDomaine { get; set; }

    }
}
