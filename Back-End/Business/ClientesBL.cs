using AutoMapper;
using Business.Interface;
using DataAccess.Entities;
using DataTransferObject;
using Microsoft.Extensions.Configuration;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;
using System.Transactions;

namespace Business
{
    public class ClientesBL: IClientesBL<ClientesDTO>
    {
        private ClientesRepository repo = null;
        private IUnitOfWorkFactory uowF = null;
        readonly IMapper mapperBase;

        public ClientesBL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Clientes, ClientesDTO>()
                    .ForMember(dest=> dest.NombreEstado, opt=> opt.MapFrom(src => src.IdEstadoNavigation.NombreEstado))
                ;
                cfg.CreateMap<ClientesDTO,Clientes>();
                cfg.CreateMap<Estados, EstadosDTO>().ReverseMap();
            });
            mapperBase = config.CreateMapper();
        }
        public IEnumerable<ClientesDTO> GetAll()
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new ClientesRepository(this.uowF.GetUnitOfWork());
                var element = repo.GetAll();
                var elementDTO = mapperBase.Map<IEnumerable<Clientes>, IEnumerable<ClientesDTO>>(element.ToList());
                return elementDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<ClientesDTO> Find(string name)
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new ClientesRepository(this.uowF.GetUnitOfWork());
                var element = repo.Find(x=> x.RazonSocial.Contains(name)).ToList();
                var elementDTO = mapperBase.Map<IEnumerable<Clientes>, IEnumerable<ClientesDTO>>(element);
                return elementDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ClientesDTO FindByTipoyNroDoc(int idCliente, int IdTipoDocumento, decimal NumeroDocumento)
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new ClientesRepository(this.uowF.GetUnitOfWork());
                var element = repo.Find(x => x.IdCliente != idCliente && x.IdTipoDocumento == IdTipoDocumento && x.NumeroDocumento == NumeroDocumento).FirstOrDefault();
                var elementDTO = mapperBase.Map<Clientes, ClientesDTO>(element);
                return elementDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ClientesDTO ExistRazonSocial(int idCliente, string razonSocial)
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new ClientesRepository(this.uowF.GetUnitOfWork());
                var element = repo.Find(x => x.IdCliente != idCliente && x.RazonSocial == razonSocial).FirstOrDefault();
                var elementDTO = mapperBase.Map<Clientes, ClientesDTO>(element);
                return elementDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClientesDTO> FindByIdFarmacia(int IdFarmacia) {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new ClientesRepository(this.uowF.GetUnitOfWork());
                var element = repo.FindByIdFarmacia(IdFarmacia);
                var elementDTO = mapperBase.Map<IEnumerable<Clientes>, IEnumerable<ClientesDTO>>(element);
                return elementDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<ClientesDTO> FindConcatColumn(string name)
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new ClientesRepository(this.uowF.GetUnitOfWork());
                var element = repo.Find(x => new
                {
                    fullName = x.IdCliente.ToString() + x.RazonSocial
                }.fullName.Contains(name));
                var elementDTO = mapperBase.Map<IEnumerable<Clientes>, IEnumerable<ClientesDTO>>(element);
                return elementDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public void Insert(ClientesDTO clienteDTO)
        {
            throw new NotImplementedException();
        }

        public void Insert(ClientesDTO clienteDTO, string userid)
        {
            var clienteEntity = mapperBase.Map<ClientesDTO, Clientes>(clienteDTO);
            clienteEntity.FechaCreacion = DateTime.Now;
            clienteEntity.UsuarioCreacion = userid;

            var uowF = new TransactionScopeUnitOfWorkFactory(IsolationLevel.ReadUncommitted);

            using (IUnitOfWork unitOfWork = uowF.GetUnitOfWork(IsolationLevel.ReadUncommitted))
            {
                var repoClientes = new ClientesRepository(unitOfWork);
            
                clienteEntity = repoClientes.Insert(clienteEntity);

                
                
                unitOfWork.Commit();
            }
        }

        public void Update(ClientesDTO cliente) 
        {
            throw new NotImplementedException();
        }

        public void Update(ClientesDTO cliente, string userid)
        {
            Estados estadoAnterior;

            var ClienteEntity = mapperBase.Map<ClientesDTO, Clientes>(cliente);
            ClienteEntity.FechaUltimaModificacion = DateTime.Now;
            ClienteEntity.UsuarioUltimaModificacion = userid;

            // Read Data
            var readUOWF = new TransactionScopeUnitOfWorkFactory(IsolationLevel.Serializable);
            using (IUnitOfWork unitOfWork = readUOWF.GetUnitOfWork(IsolationLevel.Serializable))
            {
                var clientesRepo = new ClientesRepository(unitOfWork);
                estadoAnterior = clientesRepo
                    .Find(c => c.IdCliente == cliente.IdCliente)
                    .Select(c => new Estados {
                        IdEstado = c.IdEstado
                    })
                    .FirstOrDefault();
            }

            // Write Data
            var uowF = new TransactionScopeUnitOfWorkFactory(IsolationLevel.ReadUncommitted);
            using (IUnitOfWork unitOfWork = this.uowF.GetUnitOfWork(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var repoClientes = new ClientesRepository(unitOfWork);
                   
                    repoClientes.Update(ClienteEntity);

                  

                    
                    // Estados
                   
                    if(ClienteEntity.IdEstado == (int)StaticClass.Constants.EstadosPROVCLI.INHABILITADO && 
                        estadoAnterior.IdEstado != ClienteEntity.IdEstado)
                    {
                       
                    }

                    unitOfWork.Commit();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
        public ClientesDTO Single(object primaryKey)
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new ClientesRepository(this.uowF.GetUnitOfWork());
                var element = repo.Single(primaryKey);
                var elementDTO = mapperBase.Map<Clientes, ClientesDTO>(element);
               
                return (ClientesDTO)elementDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ClientesDTO SingleOrDefault(object primaryKey)
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new ClientesRepository(this.uowF.GetUnitOfWork());
                var element = repo.SingleOrDefault(primaryKey);
                var elementDTO = mapperBase.Map<Clientes, ClientesDTO>(element);
               // elementDTO.TiposDocumentoDTO = mapperBase.Map<TiposDeDocumentos, TiposDeDocumentoDTO>(element.IdTipoDocumentoNavigation);
                return (ClientesDTO)elementDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Exists(object primaryKey)
        {
            throw new NotImplementedException();
        }
        public void InsertRange(IEnumerable<ClientesDTO> entities)
        {
            throw new NotImplementedException();
        }
        public void UpdateRange(IEnumerable<ClientesDTO> entities)
        {
            throw new NotImplementedException();
        }
        
        public void Delete(ClientesDTO dto, string userid)
        {
            try
            {
                var element = mapperBase.Map<ClientesDTO, Clientes>(dto);
                uowF = new TransactionScopeUnitOfWorkFactory(IsolationLevel.ReadUncommitted);
                using (IUnitOfWork unitOfWork = this.uowF.GetUnitOfWork(IsolationLevel.ReadUncommitted))
                {
                    repo = new ClientesRepository(unitOfWork);
                    element.IdEstado = (int) StaticClass.Constants.EstadosPROVCLI.INHABILITADO;
                    element.UsuarioUltimaModificacion = userid;
                    element.FechaUltimaModificacion = DateTime.Now;
                    
                    repo.Update(element);
                    unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteRange(IEnumerable<ClientesDTO> entities)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(IEnumerable<ClientesDTO> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientesDTO> Find(string where, string orderby, int skip, int top, out int count)
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new ClientesRepository(this.uowF.GetUnitOfWork());
                var element = repo.Find(where, orderby, skip, top, out count).ToList();
                var elementDTO = mapperBase.Map<IEnumerable<Clientes>, IEnumerable<ClientesDTO>>(element);
                return elementDTO.ToList();
            }
            catch (AutoMapperMappingException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ExistsByName(object primaryKey, object name)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void Delete(ClientesDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
