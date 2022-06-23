using DataTransferObject;
using System.Collections.Generic;

namespace Business.Interface
{
    public interface IClientesBL<T> : IBaseBusiness<T>
    {
        IEnumerable<T> Find(string name);
        void Insert(ClientesDTO element, string userid);
        void Update(ClientesDTO cliente, string userid);
        ClientesDTO FindByTipoyNroDoc(int idCliente, int IdTipoDocumento, decimal NumeroDocumento);
        ClientesDTO ExistRazonSocial(int idCliente, string razonSocial);
        void Delete(ClientesDTO dto, string userid);
    }
}
