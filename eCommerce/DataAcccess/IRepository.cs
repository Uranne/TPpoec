using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataAcccess
{
    public interface IRepository<T>
    {
        IEnumerable<T> Lister();
        T Trouver(int ID);
        T Ajouter(T nouveau);
        T Modifier(int id, T objet);
        bool Supprimer(int ID);
    }
}
