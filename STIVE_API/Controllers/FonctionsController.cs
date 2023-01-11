using Microsoft.AspNetCore.Mvc;
using STIVE_API.Helpers;
using STIVE_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STIVE_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FonctionsController : ControllerBase
    {
        //ACTION SUR LES FONCTIONS


        //Lister les fonctions
        [HttpGet]
        public List<Fonction> ListeFonction()
        {
            using STIVE_Context context = new STIVE_Context();
            {
                List<Fonction> fonctions = context.fonctions.ToList();
                return fonctions;
            }
        }

        //Ajouter une fonction
        [HttpPost]
        public void AjouterFonction(string Libelle)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Fonction NouvelleFonction = new Fonction();
                NouvelleFonction.LibelleFonction = Libelle;

                context.Add(NouvelleFonction);
                context.SaveChanges();
            }
        }

        //Modifier une fonction
        [HttpPut]
        public void ModifierFonction(int ID = 0, string? Libelle = null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Fonction uneFonction = context.fonctions.Where(x => x.IdFonction == ID).First();

                if (Libelle != null) { uneFonction.LibelleFonction = Libelle; }

                context.Update(uneFonction);
                context.SaveChanges();
            }
        }

        //Supprimer une fonction
        [HttpDelete]
        public void SupprimerFonction(int ID = 0)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Fonction uneFonction = context.fonctions.Where(x => x.IdFonction == ID).First();
                context.Remove(uneFonction);
                context.SaveChanges();
            }
        }
    }
}
