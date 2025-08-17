using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libralgo.Data.Abstract
{
    public interface IGenericDal<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T GetFirst();
        void Delete(int id);
        void Create(T entity);
        void Update(T entity);
    }
}
