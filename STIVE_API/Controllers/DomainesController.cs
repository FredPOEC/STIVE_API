using Microsoft.AspNetCore.Mvc;
using STIVE_API.Helpers;
using STIVE_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STIVE_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DomainesController : ControllerBase
    {
        // ACTIONS SUR LES DOMAINES

        //Lister les domaines
        [HttpGet]
        public List<Domaine> ListeDomaine()
        {
            using STIVE_Context context = new STIVE_Context();
            {
                List<Domaine> domaines = context.domaines.ToList();
                return domaines;
            }
        }

        //Ajouter un domaine
        [HttpPost]
        public void AjouterDomaine(string nom, string mail, string adresse, string codepostal, string ville, string telephone, string? descriptif = null)
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
        public void ModifierDomaine(int ID = 0, string? nom = null, string? mail = null, string? adresse = null, string? codepostal = null, string? ville = null, string? telephone = null, string? descriptif = null)
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
                Domaine unDomaine = context.domaines.Where(x => x.IdDomaine == ID).First();
                context.Remove(unDomaine);
                context.SaveChanges();
            }
        }
    }
}
