using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STIVE_API.Helpers;
using STIVE_API.Models;

namespace STIVE_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CommandeDomainesController
    {
        //ACTION SUR LES COMMANDES DOMAINES


        //Lister les commandes domaines
        [HttpGet]
        public List<CommandeDomaine> ListeCommandeDomaine   ()
        {
            using STIVE_Context context = new STIVE_Context();
            {
                List<CommandeDomaine> commandeDomaines = context.commandeDomaines.ToList();
                return commandeDomaines;
            }
        }

        //Ajouter une commande domaine
        [HttpPost]
        public void AjouterCommandeDomaine(string Libelle, int IdDomaine, int IdEtatCommande)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                CommandeDomaine NouvelleCommande = new CommandeDomaine();
                NouvelleCommande.IdDomaine = IdDomaine;
                NouvelleCommande.IdEtatCommande = IdEtatCommande;
                NouvelleCommande.DateCommandeDomaine = Convert.ToString(DateTime.Now);

                context.Add(NouvelleCommande);
                context.SaveChanges();
            }
        }

        //Modifier l'état d'une commande domaine
        [HttpPut]
        public void ModifierEtatCommandeDomaine(int ID = 0, int? IdEtatCommande=null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                CommandeDomaine uneCommandeDomaine = context.commandeDomaines.Where(x => x.IdCommandeDomaine == ID).First();

                if (IdEtatCommande != null) { uneCommandeDomaine.IdEtatCommande = IdEtatCommande; }

                context.Update(uneCommandeDomaine);
                context.SaveChanges();
            }
        }

        //Supprimer une commande domaine
        [HttpDelete]
        public void SupprimerCommandeDomaine(int ID = 0)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                CommandeDomaine uneCommandeDomaine = context.commandeDomaines.Where(x => x.IdCommandeDomaine == ID).First();
                context.Remove(uneCommandeDomaine);
                List<LigneCommandeDomaine> ListeCommandeDomaine = context.ligneCommandeDomaines.Where(x => x.IdCommandeDomaine == ID).ToList();
                foreach (LigneCommandeDomaine item in ListeCommandeDomaine)
                {
                    context.Remove(item);
                }
                context.SaveChanges();
            }
        }
    }
}
