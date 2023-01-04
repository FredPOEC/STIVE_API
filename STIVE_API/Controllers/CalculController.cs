using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using STIVE_API.Models;
using STIVE_API.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace STIVE_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class CalculController : Controller
    {
  
        public CalculController ()
        {
            
        }

                                                                // ACTIONS SUR LES ARTICLES

        private double PrixparCarton(string PrixUnitaire, string Nombre, string Ristourne )
        {
            double prix;
            prix = Math.Round(Convert.ToDouble(PrixUnitaire)*Convert.ToInt32(Nombre)*Convert.ToDouble(Ristourne),0)-0.01;
            return prix;
        }

        //Renvoyer la liste des articles
        [HttpGet]
        public List<Article> ListeArticle()
        {
            using STIVE_Context context = new STIVE_Context();
            {
                {
                    List<Article> Articles = context.articles.ToList();
                    return Articles;
                }
            }
        }
   
        //Ajouter un article
        [HttpPost]
        public void AjouterArticle(string nom, string annee, string prixVenteHT, string prixAchatHT, string IdFamille, 
            string IdDomaine, string IdTva, string? ristourne = null, string? nbCarton = null,string ? descriptif=null, 
            string? image=null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Article NouvelArticle = new Article();
                NouvelArticle.NomArticle = nom;
                NouvelArticle.AnneeArticle = annee;
                NouvelArticle.DescriptifArticle = descriptif;
                NouvelArticle.ImageArticle = image;
                NouvelArticle.PrixVentehtArticle = Convert.ToDouble(prixVenteHT);
                NouvelArticle.NbDansCartonArticle = Convert.ToInt32(nbCarton);
                NouvelArticle.RistourneCartonArticle = Convert.ToDouble(ristourne);
                NouvelArticle.PrixVenteCartonhtArticle = PrixparCarton(prixVenteHT, nbCarton, ristourne);
                NouvelArticle.PrixAchathtArticle = Convert.ToDouble(prixAchatHT);   
                NouvelArticle.IdFamille = Convert.ToInt32(IdFamille);
                NouvelArticle.IdDomaine= Convert.ToInt32(IdDomaine);
                NouvelArticle.IdTVA = Convert.ToInt32(IdTva);

                context.Add(NouvelArticle);
                context.SaveChanges();
            }
        }

        //Modifier un article
        [HttpPut]
        public void ModifierArticle(int ID = 0, string? nom=null, string? annee=null, string? prixVenteHT=null, string? nbCarton=null, string? ristourne=null, string? prixVenteCarton=null, string? prixAchatHT=null,  string? IdFamille=null, string? IdDomaine=null, string? IdTva=null, string? descriptif=null, string? image=null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Article unArticle = context.articles.Where(x => x.IdArticle == ID).First();

                if (nom != null) { unArticle.NomArticle = nom; }
                if (annee != null) { unArticle.AnneeArticle = annee; }
                if (nbCarton !=null) { unArticle.NbDansCartonArticle = Convert.ToInt32(nbCarton); }
                if (ristourne !=null) { unArticle.RistourneCartonArticle = Convert.ToDouble(ristourne); }
                if (prixVenteHT != null) { unArticle.PrixVentehtArticle = Convert.ToDouble(prixVenteHT); unArticle.PrixVenteCartonhtArticle = PrixparCarton(prixVenteHT, nbCarton, ristourne); }
                if (prixVenteCarton !=null) { unArticle.PrixVenteCartonhtArticle = Convert.ToDouble(prixVenteCarton); }
                if (prixAchatHT != null) { unArticle.PrixAchathtArticle = Convert.ToDouble(prixAchatHT); }
                if (IdFamille !=null) { unArticle.IdFamille = Convert.ToInt32(IdFamille); }
                if (IdDomaine != null) { unArticle.IdDomaine = Convert.ToInt32(IdDomaine); }
                if (descriptif !=null) { unArticle.DescriptifArticle = descriptif; }
                if (image != null) { unArticle.ImageArticle = image; }
                if (IdTva !=null) { unArticle.IdTVA= Convert.ToInt32(IdTva); }

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

        // ACTIONS SUR LES UTILISATEURS

        //Lister les utilisateurs
        [HttpGet]
        public List<Utilisateur> ListeUtilisateur ()
        {
            using STIVE_Context context = new STIVE_Context();
            {

                {
                    List<Utilisateur> utilisateurs = context.utilisateurs.ToList();
                    return utilisateurs;
                }

            }
        }

        //Ajouter un utilisateur
        [HttpPost]
        public void AjouterUtilisateur(string nom, string prenom, string mail, string adresse, string codepostal, string ville, string idfonction, string? telephone=null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Utilisateur NouvelUtilisateur = new Utilisateur();
                NouvelUtilisateur.NomUtilisateur = nom;
                NouvelUtilisateur.PrenomUtilisateur = prenom;
                NouvelUtilisateur.MailUtilisateur = mail;
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
        public void ModifierUtilisateur(int ID = 0, string? nom=null , string? prenom=null, string? mail=null, string? adresse=null, string? codepostal=null, string? ville=null, string? telephone = null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Utilisateur unUtilisateur = context.utilisateurs.Where(x => x.IdUtilisateur == ID).First();

                if (nom != null) { unUtilisateur.NomUtilisateur = nom; }
                if (prenom != null) { unUtilisateur.PrenomUtilisateur = prenom; }
                if (mail != null) { unUtilisateur.MailUtilisateur = mail; }
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

        // ACTIONS SUR LES DOMAINES

        //Lister les domaines
        [HttpGet]
        public List<Domaine> ListeDomaine ()
        {
            using STIVE_Context context = new STIVE_Context();
            {

                {
                    List<Domaine> domaines = context.domaines.ToList();
                    return domaines;
                }

            }
        }

        //Ajouter un domaine
        [HttpPost]
        public void AjouterDomaine(string nom, string mail, string adresse, string codepostal, string ville, string telephone, string? descriptif=null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Domaine NouveauDomaine = new Domaine();
                NouveauDomaine.NomDomaine = nom;
                NouveauDomaine.MailDomaine = mail;
                NouveauDomaine.DescriptifDomaine = descriptif;
                NouveauDomaine.AdresseDomaine = adresse;
                NouveauDomaine.CodePostalDomaine = codepostal;
                NouveauDomaine.VilleDomaine = ville;
                NouveauDomaine.TelephoneDomaine = telephone;

                context.Add(NouveauDomaine);
                context.SaveChanges();
            }
        }

        //Modifier un domaine
        [HttpPut]
        public void ModifierDomaine (int ID=0, string? nom=null, string? mail=null, string? adresse=null, string? codepostal=null, string? ville=null, string? telephone=null, string? descriptif=null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Domaine unDomaine = context.domaines.Where(x => x.IdDomaine == ID).First();

                if (nom != null) { unDomaine.NomDomaine = nom; }
                if (mail != null) { unDomaine.MailDomaine = mail; }
                if (adresse != null) { unDomaine.AdresseDomaine = adresse; }
                if (codepostal != null) { unDomaine.CodePostalDomaine = codepostal; }
                if (ville != null) { unDomaine.VilleDomaine = ville; }
                if (telephone != null) { unDomaine.TelephoneDomaine = telephone; }
                if (descriptif != null) { unDomaine.DescriptifDomaine = descriptif; }

                context.Update(unDomaine);
                context.SaveChanges();
            }
        }

        //Supprimer un domaine
        [HttpDelete]
        public void SupprimerDomaine(int ID = 0)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Domaine unDomaine    = context.domaines.Where(x => x.IdDomaine == ID).First();
                context.Remove(unDomaine);
                context.SaveChanges();
            }
        }



        //ACTION SUR LES FAMILLES DE VINS

        //Renvoyer liste des familles
        [HttpGet]
        public List<Famille> ListeFamille()
        {
            using STIVE_Context context = new STIVE_Context();
            {

                {
                    List<Famille> familles = context.familles.ToList();
                    return familles;
                }

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


        //ACTION SUR LA TVA

        //Lister les taux de TVA
        [HttpGet]
        public List<Tva> ListeTVA()
        {
            using STIVE_Context context = new STIVE_Context();
            {

                {
                    List<Tva> tvas = context.tvas.ToList();
                    return tvas;
                }

            }
        }

        //Ajouter un taux de TVA
        [HttpPost]
        public void AjouterTVA(double Taux)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Tva NouvelleTva = new Tva();
                NouvelleTva.TauxTva = Taux;
                NouvelleTva.LibelleTVA = Taux + "%";

                context.Add(NouvelleTva);
                context.SaveChanges();
            }
        }

        //Modifier une TVA
        [HttpPut]
        public void ModifierTva(int ID = 0, string? taux = null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Tva uneTva = context.tvas.Where(x => x.IdTva == ID).First();

                if (taux != null) { uneTva.TauxTva = Convert.ToDouble(taux); uneTva.LibelleTVA = taux + "%"; }

                context.Update(uneTva);
                context.SaveChanges();
            }
        }

        //Supprimer une TVA
        [HttpDelete]
        public void SupprimerTva(int ID = 0)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Tva uneTva = context.tvas.Where(x => x.IdTva == ID).First();
                context.Remove(uneTva);
                context.SaveChanges();
            }
        }

        //ACTION SUR LES FONCTIONS


        //Lister les fonctions
        [HttpGet]
        public List<Fonction> ListeFonction()
        {
            using STIVE_Context context = new STIVE_Context();
            {

                {
                    List<Fonction> fonctions = context.fonctions.ToList();
                    return fonctions;
                }

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
