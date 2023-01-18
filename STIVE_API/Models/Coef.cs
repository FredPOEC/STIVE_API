using System.ComponentModel.DataAnnotations;

namespace STIVE_API.Models
{
    public class Coef
    {
        [Key]
        public int IdCoef { get; set; }
        [Required]
        public double ValeurCoef { get; set; }

        public string? LibelleCoef { get; set; }
    }

}
