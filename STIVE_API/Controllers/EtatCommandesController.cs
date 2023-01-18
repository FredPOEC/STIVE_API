using Microsoft.AspNetCore.Mvc;
using STIVE_API.Helpers;
using STIVE_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STIVE_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EtatCommandesController : ControllerBase
    {
        //ACTION SUR L'ETAT DES COMMANDES

        //Lister les états de commandes
        [HttpGet]
        public List<EtatCommande> ListeEtatCommande()
        {
            using STIVE_Context context = new STIVE_Context();
            {

                {
                    List<EtatCommande> etatCommandes = context.etatCommandes.ToList();
                    return etatCommandes;
                }

            }
        }

        //Ajouter un état de commande
        [HttpPost]
        public void AjouterEtatCommande(string libelle)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                EtatCommande NouvelEtat = new EtatCommande();
                NouvelEtat.LibelleEtatCommande = libelle;

                context.Add(NouvelEtat);
                context.SaveChanges();
            }
        }


        //Supprimer un état de commande
        [HttpDelete]
        public void SupprimerEtatCommande(int ID = 0)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                EtatCommande unEtatCommande = context.etatCommandes.Where(x => x.IdEtatCommande == ID).First();
                context.Remove(unEtatCommande);
                context.SaveChanges();
            }
        }

    }
}
