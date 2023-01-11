using Microsoft.AspNetCore.Mvc;
using STIVE_API.Helpers;
using STIVE_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STIVE_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FamillesController : ControllerBase
    {
        //ACTION SUR LES FAMILLES DE VINS

        //Renvoyer liste des familles
        [HttpGet]
        public List<Famille> ListeFamille()
        {
            using STIVE_Context context = new STIVE_Context();
            {
                List<Famille> familles = context.familles.ToList();
                return familles;
            }
        }

        //Ajouter une famille
        [HttpPost]
        public void AjouterFamille(string libelle)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Famille NouvelleFamille = new Famille();
                NouvelleFamille.LibelleFamille = libelle;

                context.Add(NouvelleFamille);
                context.SaveChanges();
            }
        }

        //Modifier une famille
        [HttpPut]
        public void ModifierFamille(int ID = 0, string? libelle = null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Famille uneFamille = context.familles.Where(x => x.IdFamille == ID).First();

                if (libelle != null) { uneFamille.LibelleFamille = libelle; }

                context.Update(uneFamille);
                context.SaveChanges();
            }
        }

        //Supprimer une famille
        [HttpDelete]
        public void SupprimerFamille(int ID = 0)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Famille uneFamille = context.familles.Where(x => x.IdFamille == ID).First();
                context.Remove(uneFamille);
                context.SaveChanges();
            }
        }
    }
}
