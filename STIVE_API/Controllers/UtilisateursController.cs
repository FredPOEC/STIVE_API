using Microsoft.AspNetCore.Mvc;
using STIVE_API.Helpers;
using STIVE_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STIVE_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        // ACTIONS SUR LES UTILISATEURS

        //Lister les utilisateurs
        [HttpGet]
        public List<Utilisateur> ListeUtilisateur()
        {
            using STIVE_Context context = new STIVE_Context();
            {
                List<Utilisateur> utilisateurs = context.utilisateurs.ToList();
                return utilisateurs;
            }
        }

        //Ajouter un utilisateur
        [HttpPost]
        public void AjouterUtilisateur(string nom, string prenom, string mail, string adresse, string codepostal, string ville, string idfonction, string? mdp = null, string? telephone = null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Utilisateur NouvelUtilisateur = new Utilisateur();
                NouvelUtilisateur.NomUtilisateur = nom;
                NouvelUtilisateur.PrenomUtilisateur = prenom;
                NouvelUtilisateur.MailUtilisateur = mail;
                NouvelUtilisateur.MotdePasseUtilisateur = mdp;
                NouvelUtilisateur.AdresseUtilisateur = adresse;
                NouvelUtilisateur.CodePostalUtilisateur = codepostal;
                NouvelUtilisateur.VilleUtilisateur = ville;
                NouvelUtilisateur.TelephoneUtilisateur = telephone;
                NouvelUtilisateur.IdFonction = Convert.ToInt32(idfonction);

                context.Add(NouvelUtilisateur);
                context.SaveChanges();
            }
        }

        //Modifier un utilisateur
        [HttpPut]
        public void ModifierUtilisateur(int ID = 0, string? nom = null, string? prenom = null, string? mail = null, string? adresse = null, string? codepostal = null, string? mdp=null, string? ville = null, string? telephone = null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Utilisateur unUtilisateur = context.utilisateurs.Where(x => x.IdUtilisateur == ID).First();

                if (nom != null) { unUtilisateur.NomUtilisateur = nom; }
                if (prenom != null) { unUtilisateur.PrenomUtilisateur = prenom; }
                if (mail != null) { unUtilisateur.MailUtilisateur = mail; }
                if (mdp != null) { unUtilisateur.MotdePasseUtilisateur = mdp; }
                if (adresse != null) { unUtilisateur.AdresseUtilisateur = adresse; }
                if (codepostal != null) { unUtilisateur.CodePostalUtilisateur = codepostal; }
                if (ville != null) { unUtilisateur.VilleUtilisateur = ville; }
                if (telephone != null) { unUtilisateur.TelephoneUtilisateur = telephone; }


                context.Update(unUtilisateur);
                context.SaveChanges();
            }
        }

        //Supprimer un utilisateur
        [HttpDelete]
        public void SupprimerUtilisateur(int ID = 0)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Utilisateur unUtilisateur = context.utilisateurs.Where(x => x.IdUtilisateur == ID).First();
                context.Remove(unUtilisateur);
                context.SaveChanges();
            }
        }
    }
}
