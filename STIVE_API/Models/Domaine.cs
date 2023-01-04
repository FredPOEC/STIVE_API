using System.ComponentModel.DataAnnotations;

namespace STIVE_API.Models
{
    public class Domaine
    {
        [Key]
        public int IdDomaine { get; set; }
        [Required]
        public string NomDomaine { get; set; }
     
        public string? DescriptifDomaine { get; set; }
        [Required]
        public string MailDomaine { get; set; }
        [Required]               
        public string AdresseDomaine { get; set; }
        [Required]
        public string CodePostalDomaine { get; set; }
        [Required]
        public string VilleDomaine { get; set; }
        public string TelephoneDomaine { get; set; }
    }
}
