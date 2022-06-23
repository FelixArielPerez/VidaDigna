using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IEstadosBL<T>
    {
        public IEnumerable<T> Find(string name);
        public IEnumerable<T> GetById(int id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetAllByTipo(string tipo);
    }
}
