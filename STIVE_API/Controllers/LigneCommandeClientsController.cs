using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STIVE_API.Helpers;
using STIVE_API.Models;

namespace STIVE_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LigneCommandeClientsController
    {
        //Rechercher les lignes de commande par IDcommande
        [HttpGet]
        public List<LigneCommandeClient>? RechercherLigneCommandeClients (int IDCommande) 
        {
            using STIVE_Context context = new STIVE_Context();
            {
                List<LigneCommandeClient>? ListeLigne = null;
                ListeLigne = context.ligneCommandeClients.Where(x => x.IdCommandeClient == IDCommande).ToList();
                return ListeLigne;
            }

        }

        //Ajouter une ligne de commande
        [HttpPost]
        public void AjouterLigneCommandeClients(int quantite, double prixHT, double tauxTVA, int IdArticle, int IdCommande)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                LigneCommandeClient NouvelleLigne = new LigneCommandeClient();
                NouvelleLigne.QuantiteLigneCommandeClient = quantite;
                NouvelleLigne.PrixAchathtLigneCommandeClient = prixHT;
                NouvelleLigne.TauxTVALigneCommandeClient= tauxTVA;
                NouvelleLigne.IdArticle= IdArticle;
                NouvelleLigne.IdCommandeClient= IdCommande;

                context.Add(NouvelleLigne);
                context.SaveChanges();
            }
        }

        //Modifier la quantité sur une ligne de commande
        [HttpPut]
        public void ModifierLigneCommandeCLients(int ID, int? quantite = null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                LigneCommandeClient uneLigneCommande = context.ligneCommandeClients.Where(x => x.IdLigneCommandeClient == ID).First();

                if (quantite != null) { uneLigneCommande.QuantiteLigneCommandeClient = quantite; }

                context.Update(uneLigneCommande);
                context.SaveChanges();
            }
        }

        //Supprimer une ligne de commande client
        [HttpDelete]
        public void SupprimerLigneCommandeClient(int ID = 0)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                LigneCommandeClient uneLigneCommande = context.ligneCommandeClients.Where(x => x.IdLigneCommandeClient == ID).First();
                context.Remove(uneLigneCommande);
                context.SaveChanges();
            }
        }

    }
}
