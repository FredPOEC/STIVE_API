using Microsoft.AspNetCore.Mvc;
using STIVE_API.Helpers;
using STIVE_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STIVE_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CommandeClientsController 
    {
        //ACTION SUR LES COMMANDES CLIENTS


        //Lister les commandes clients
        [HttpGet]
        public List<CommandeClient> ListeCommandeClient()
        {
            using STIVE_Context context = new STIVE_Context();
            {
                List<CommandeClient> commandeClients = context.commandeClients.ToList();
                return commandeClients;
            }
        }

        //Ajouter une commande client
        [HttpPost]
        public void AjouterCommandeCLient(string Libelle, int IdClient, int IdEtatCommande)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                CommandeClient NouvelleCommande = new CommandeClient();
                NouvelleCommande.IdClient = IdClient ;
                NouvelleCommande.IdEtatCommande= IdEtatCommande ;
                NouvelleCommande.DateCommandeClient = Convert.ToString(DateTime.Now);

                context.Add(NouvelleCommande);
                context.SaveChanges();
            }
        }

        //Modifier l'état d'une commande client
        [HttpPut]
        public void ModifierEtatCommandeClient(int ID = 0, int? IdEtatCommande=null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                CommandeClient uneCommandeClient = context.commandeClients.Where(x => x.IdCommandeClient == ID).First();

                if (IdEtatCommande != null) { uneCommandeClient.IdEtatCommande = IdEtatCommande; }

                context.Update(uneCommandeClient);
                context.SaveChanges();
            }
        }

        //Supprimer une commande client
        [HttpDelete]
        public void SupprimerCommandeClient(int ID = 0)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                CommandeClient uneCommandeClient = context.commandeClients.Where(x => x.IdCommandeClient == ID).First();
                context.Remove(uneCommandeClient);
                List<LigneCommandeClient> ListeCommandeClient = context.ligneCommandeClients.Where(x => x.IdCommandeClient == ID).ToList();
                foreach (LigneCommandeClient item in ListeCommandeClient )
                {
                    context.Remove(item);
                }
                context.SaveChanges();
            }
        }
    }
}
