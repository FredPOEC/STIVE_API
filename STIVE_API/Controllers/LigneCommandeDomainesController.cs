using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STIVE_API.Helpers;
using STIVE_API.Models;

namespace STIVE_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LigneCommandeDomainesController : ControllerBase
    {
        //Rechercher les lignes de commande par IDcommande
        [HttpGet]
        public List<LigneCommandeDomaine>? RechercherLigneCommandeDomaines(int IDCommande)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                List<LigneCommandeDomaine>? ListeLigne = null;
                ListeLigne = context.ligneCommandeDomaines.Where(x => x.IdCommandeDomaine == IDCommande).ToList();
                return ListeLigne;
            }

        }

        //Ajouter une ligne de commande
        [HttpPost]
        public void AjouterLigneCommandeDomaines(int quantite, double prixHT,  int IdArticle, int IdCommande)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                LigneCommandeDomaine NouvelleLigne = new LigneCommandeDomaine();
                NouvelleLigne.QuantiteLigneCommandeDomaine = quantite;
                NouvelleLigne.PrixAchathtLigneCommandeDomaines = prixHT;
                NouvelleLigne.IdArticle = IdArticle;
                NouvelleLigne.IdCommandeDomaine = IdCommande;

                context.Add(NouvelleLigne);
                context.SaveChanges();
            }
        }

        //Modifier la quantité sur une ligne de commande
        [HttpPut]
        public void ModifierLigneCommandeDomaines(int ID, int? quantite = null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                LigneCommandeDomaine uneLigneCommande = context.ligneCommandeDomaines.Where(x => x.IdLigneCommandeDomaine == ID).First();

                if (quantite != null) { uneLigneCommande.QuantiteLigneCommandeDomaine = quantite; }

                context.Update(uneLigneCommande);
                context.SaveChanges();
            }
        }

        //Supprimer une ligne de commande domaine
        [HttpDelete]
        public void SupprimerLigneCommandeClient(int ID = 0)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                LigneCommandeDomaine uneLigneCommande = context.ligneCommandeDomaines.Where(x => x.IdLigneCommandeDomaine == ID).First();
                context.Remove(uneLigneCommande);
                context.SaveChanges();
            }
        }

    }
}
