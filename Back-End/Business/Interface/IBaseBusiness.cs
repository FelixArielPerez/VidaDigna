using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IBaseBusiness<T>
    {
        T Single(object primaryKey);

        T SingleOrDefault(object primaryKey);

        IEnumerable<T> GetAll();

        bool Exists(object primaryKey);

        bool ExistsByName(object primaryKey, object name);

        void Insert(T entity);

        void InsertRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        bool RemoveRange(IEnumerable<T> entities);
        IEnumerable<T> Find(string where, string orderby, int skip, int top, out int count);
    }
}
