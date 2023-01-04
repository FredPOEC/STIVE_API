using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STIVE_API.Models
{
    public class Utilisateur
    {
        [Key]
        public int IdUtilisateur { get; set; }
        [Required]
        public string NomUtilisateur { get; set; }

        [Required]
        public string PrenomUtilisateur { get; set; }

        [Required]
        public string MailUtilisateur { get; set; }

        [Required]
        public  string MotdePasseUtilisateur { get; set; }
        [Required]

        public string AdresseUtilisateur { get; set; }
        [Required]
        public string CodePostalUtilisateur { get; set; }

        [Required]
        public string VilleUtilisateur { get; set; }
        
        public string TelephoneUtilisateur { get; set; }

        [Required, ForeignKey("fonctions")]
        public int IdFonction { get; set; }

    }
}
