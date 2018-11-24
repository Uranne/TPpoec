using eCommerce.DataAccess;
using eCommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.DataAcccess
{
    public class EFProduitRepository: EFRepository<Produit>
    {
        EFModelTirelire bdd = new EFModelTirelire();

        public new IEnumerable<Produit> Lister()
        {
            return bdd.Set<Produit>().Include("Photos").ToList();
        }

        public new Produit Trouver(int ID)
        {
            try
            {
                return bdd.Set<Produit>().Include("Photos").Where(p=>p.Id==ID).First();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("La suppression de l'élément dans la base de donnée n'a pas fonctionné : {0}", e.Message));
            }
        }
    }
}