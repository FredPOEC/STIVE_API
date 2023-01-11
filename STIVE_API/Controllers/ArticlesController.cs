using System.ComponentModel;
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
        [Description("Liste pour une famille")]
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





        //Renvoyer la liste des articles
        [HttpGet]
        public List<Article> ListeArticle()
        {
            using STIVE_Context context = new STIVE_Context();
            {
                List<Article> Articles = context.articles.ToList();
                return Articles;
            }
        }

        //Ajouter un article
        [HttpPost]
        public void AjouterArticle(string nom, string annee, string stock, string prixVenteHT, string prixAchatHT, string IdFamille,
            string IdDomaine, string IdTva,  string? descriptif = null, string? image = null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Article NouvelArticle = new Article();
                NouvelArticle.NomArticle = nom;
                NouvelArticle.AnneeArticle = annee;
                NouvelArticle.QuantiteEnStock = Convert.ToInt32(stock);
                NouvelArticle.DescriptifArticle = descriptif;
                NouvelArticle.ImageArticle = image;
                NouvelArticle.PrixVentehtArticle = Convert.ToDouble(prixVenteHT);
                NouvelArticle.PrixAchathtArticle = Convert.ToDouble(prixAchatHT);
                NouvelArticle.IdFamille = Convert.ToInt32(IdFamille);
                NouvelArticle.IdDomaine = Convert.ToInt32(IdDomaine);
                NouvelArticle.IdTVA = Convert.ToInt32(IdTva);

                context.Add(NouvelArticle);
                context.SaveChanges();
            }
        }

        //Modifier un article
        [HttpPut]
        public void ModifierArticle(int ID = 0, string? nom = null, string? annee = null, string? stock = null, 
            string? prixVenteHT = null,string? prixAchatHT = null, string? IdFamille = null, string? IdDomaine = null,
            string? IdTva = null, string? descriptif = null, string? image = null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Article unArticle = context.articles.Where(x => x.IdArticle == ID).First();

                if (nom != null) { unArticle.NomArticle = nom; }
                if (annee != null) { unArticle.AnneeArticle = annee; }
                if (stock != null) { unArticle.QuantiteEnStock = Convert.ToInt32(stock); }
                if (prixVenteHT != null) { unArticle.PrixVentehtArticle = Convert.ToDouble(prixVenteHT); }
                if (prixAchatHT != null) { unArticle.PrixAchathtArticle = Convert.ToDouble(prixAchatHT); }
                if (IdFamille != null) { unArticle.IdFamille = Convert.ToInt32(IdFamille); }
                if (IdDomaine != null) { unArticle.IdDomaine = Convert.ToInt32(IdDomaine); }
                if (descriptif != null) { unArticle.DescriptifArticle = descriptif; }
                if (image != null) { unArticle.ImageArticle = image; }
                if (IdTva != null) { unArticle.IdTVA = Convert.ToInt32(IdTva); }

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
