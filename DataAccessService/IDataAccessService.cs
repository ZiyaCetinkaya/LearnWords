using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService
{
    public interface IDataAccessService<T> where T : class
    {
        T FindByID(object EntityID);
        List<T> Select(Expression<Func<T, bool>> Filter = null);
        void Insert(T Entity);
        void Update(T Entity);
        T FindByLambda(Expression<Func<T, bool>> Filter = null);
        void Delete(T Entity);
    }
}
