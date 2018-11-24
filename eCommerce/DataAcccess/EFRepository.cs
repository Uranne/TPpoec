using eCommerce.DataAcccess;
using eCommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.DataAccess
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        EFModelTirelire bdd = new EFModelTirelire();

        public T Ajouter(T nouveau)
        {
            try
            {
                T retour;
                retour = bdd.Set<T>().Add(nouveau);
                bdd.SaveChanges();
                return retour;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("L'ajout dans la base de donnée n'a pas fonctionné : {0}", e.Message));
            }
        }

        public virtual IEnumerable<T> Lister()
        {
            return bdd.Set<T>().ToList();
        }

        public T Modifier(int id, T objet)
        {
            try
            {
                T entity = bdd.Set<T>().Find(id);
                bdd.Entry<T>(entity).CurrentValues.SetValues(objet);
                bdd.SaveChanges();
                return bdd.Set<T>().Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("La modification de l'élément dans la base de donnée n'a pas fonctionné : {0}", e.Message));
            }
        }

        public bool Supprimer(int ID)
        {
            try
            {
                bdd.Set<T>().Remove(bdd.Set<T>().Find(ID));
                bdd.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("La suppression de l'élément dans la base de donnée n'a pas fonctionné : {0}", e.Message));
            }
        }

        public T Trouver(int ID)
        {
            try
            {
                return bdd.Set<T>().Find(ID);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("La suppression de l'élément dans la base de donnée n'a pas fonctionné : {0}", e.Message));
            }
        }
    }
}