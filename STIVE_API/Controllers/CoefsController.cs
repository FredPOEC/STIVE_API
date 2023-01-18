using Microsoft.AspNetCore.Mvc;
using STIVE_API.Helpers;
using STIVE_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STIVE_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CoefsController : ControllerBase
    {
        //ACTION SUR LES COEFS DE MARGE

        //Lister les coefs de marge
        [HttpGet]
        public List<Coef> ListeCoef()
        {
            using STIVE_Context context = new STIVE_Context();
            {

                {
                    List<Coef> coefs = context.coefs.ToList();
                    return coefs;
                }

            }
        }

        //Ajouter un coef de marge
        [HttpPost]
        public void AjouterCoef(double Coef, string? Libelle=null)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Coef NouveauCoef = new Coef();
                NouveauCoef.ValeurCoef = Coef;
                NouveauCoef.LibelleCoef = Libelle;

                context.Add(NouveauCoef);
                context.SaveChanges();
            }
        }


        //Supprimer un coef de marge
        [HttpDelete]
        public void SupprimerCoef(int ID = 0)
        {
            using STIVE_Context context = new STIVE_Context();
            {
                Coef unCoef = context.coefs.Where(x => x.IdCoef == ID).First();
                context.Remove(unCoef);
                context.SaveChanges();
            }
        }
    }
}
