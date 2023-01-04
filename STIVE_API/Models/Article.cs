﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STIVE_API.Models
{
    public class Article
    {
        [Key]
        public int IdArticle { get; set; }
        [Required]
        public string NomArticle { get; set; }
      
        public string? DescriptifArticle { get; set; }

        public string? ImageArticle { get; set; }

        [Required]
        public double PrixVentehtArticle { get; set; }

        public double? RistourneCartonArticle { get; set; }
        public int? NbDansCartonArticle { get; set; }


        public double? PrixVenteCartonhtArticle { get; set; }


        [Required]
        public double PrixAchathtArticle { get; set; }

        [Required]
        public string AnneeArticle { get; set; }

        [Required, ForeignKey("familles")]
        public int IdFamille { get; set; }
        [Required, ForeignKey("domaines")]
        public int IdDomaine { get; set; }
        [Required, ForeignKey("tvas")]
        public int IdTVA { get; set; }
        
    }
}

