﻿using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using STIVE_API.Helpers;
using STIVE_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STIVE_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ArticlesController 
    {


        // ACTIONS SUR LES ARTICLES



        //Renvoyer la liste des articles par famille
        [HttpGet]
        public List<Article> ListeArticleParFamille(int IDFamille)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                List<Article> Articles = context.articles.Where(x => x.IdFamille == IDFamille).ToList();
                return Articles;
            }
        }

        //Renvoyer la liste des articles par domaine
        [HttpGet(Name = "Liste des articles par domaines")]
        public List<Article> ListeArticleParDomaine(int IDDomaine)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                List<Article> Articles = context.articles.Where(x => x.IdDomaine == IDDomaine).ToList();
                return Articles;
            }
        }

        //Renvoyer la liste des articles triés par Familles et par Domaines
        [HttpGet]
        public List<Article> ListeArticle()
        {
            using STIVE_Context context = new STIVE_Context();
            {
                List<Article> Articles = context.articles
                           // .OrderBy(x => x.IdFamille)
                           // .ThenBy(x => x.IdDomaine)
                            .ToList();
                return Articles;
            }
        }

        //Ajouter un article
        [HttpPost]
        public void AjouterArticle(string nom, string annee, int stock, double prixAchatHT, int IdFamille,
            int IdDomaine, int IdTva, int IdCoef, string? descriptif = null, string? image = null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Article NouvelArticle = new Article();

                NouvelArticle.NomArticle = nom;
                NouvelArticle.AnneeArticle = annee;
                NouvelArticle.QuantiteEnStock = stock;
                NouvelArticle.DescriptifArticle = descriptif;
                NouvelArticle.ImageArticle = image;
                NouvelArticle.PrixAchathtArticle = prixAchatHT;
                NouvelArticle.IdFamille = IdFamille;
                NouvelArticle.IdCoef=IdCoef;   
                NouvelArticle.IdDomaine = IdDomaine;
                NouvelArticle.IdTVA = IdTva;
                NouvelArticle.NumeroArticle = "";

                context.Add(NouvelArticle);
                context.SaveChanges();

                NouvelArticle.NumeroArticle = Convert.ToString(NouvelArticle.IdDomaine)+NouvelArticle.IdFamille + NouvelArticle.IdArticle;

                context.Update(NouvelArticle);
                context.SaveChanges();
            }
        }

        //Modifier un article
        [HttpPut]
        public void ModifierArticle(int ID = 0, string? nom = null, string? annee = null, int? stock = null, 
            double? prixAchatHT = null, int? IdCoef = null, int? IdFamille = null, int? IdDomaine = null,
            int? IdTva = null, string? descriptif = null, string? image = null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                
                Article unArticle = context.articles.Where(x => x.IdArticle == ID).First();

                if (nom != null) { unArticle.NomArticle = nom; }
                if (annee != null) { unArticle.AnneeArticle = annee; }
                if (stock != null) { unArticle.QuantiteEnStock = stock; }
                if (prixAchatHT != null) { unArticle.PrixAchathtArticle = prixAchatHT; }
                if (IdCoef != null) { unArticle.IdCoef = IdCoef; }
                if (IdFamille != null) { unArticle.IdFamille = IdFamille; }
                if (IdDomaine != null) { unArticle.IdDomaine = IdDomaine; }
                if (descriptif != null) { unArticle.DescriptifArticle = descriptif; }
                if (image != null) { unArticle.ImageArticle = image; }
                if (IdTva != null) { unArticle.IdTVA = IdTva; }
           
                
                context.Update(unArticle);
                context.SaveChanges();
            

            }
        }

        //Supprimer un article
        [HttpDelete]
        public void SupprimerArticle(int ID = 0)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Article unArticle = context.articles.Where(x => x.IdArticle == ID).First();
                context.Remove(unArticle);
                context.SaveChanges();
            }
        }
    }
}
