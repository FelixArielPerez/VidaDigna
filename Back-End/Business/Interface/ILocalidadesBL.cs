using System.Collections.Generic;
using DataTransferObject;

namespace Business.Interface
{
    public interface ILocalidadesBL<T> : IBaseBusiness<T>
    {
        public IEnumerable<LocalidadesDTO> FindByIdProvincia(int nombre);
    }
}
