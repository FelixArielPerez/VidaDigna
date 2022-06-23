using AutoMapper;
using Business.Interface;
using DataAccess.Entities;
using DataTransferObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using UnitOfWork;

namespace Business
{
    public class EstadosBL:IEstadosBL<EstadosDTO>
    {
        private EstadosRepository repo = null;
        private IUnitOfWorkFactory uowF = null;
        readonly IMapper mapperBase;

        public EstadosBL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Estados, EstadosDTO>().ReverseMap();
            });
            mapperBase = config.CreateMapper();
        }

        public IEnumerable<EstadosDTO> Find(string name)
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new EstadosRepository(this.uowF.GetUnitOfWork());
                var element = repo.Find(x => x.NombreEstado.Contains(name));
                var elementDTO = mapperBase.Map<IEnumerable<Estados>, IEnumerable<EstadosDTO>>(element.ToList());
                return elementDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<EstadosDTO> GetAll()
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new EstadosRepository(this.uowF.GetUnitOfWork());
                var element = repo.GetAll();
                var elementDTO = mapperBase.Map<IEnumerable<Estados>, IEnumerable<EstadosDTO>>(element.ToList());
                return elementDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<EstadosDTO> GetById(int id)
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new EstadosRepository(this.uowF.GetUnitOfWork());
                var element = repo.Find(x => x.IdEstado == id);
                var elementDTO = mapperBase.Map<IEnumerable<Estados>, IEnumerable<EstadosDTO>>(element.ToList());
                return elementDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<EstadosDTO> GetAllByTipo(string tipo)
        {
            try {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new EstadosRepository(uowF.GetUnitOfWork());
                IEnumerable<Estados> estados = repo.GetAllByTipo(tipo);
                IEnumerable<EstadosDTO> estadosDTO = mapperBase.Map<IEnumerable<Estados>,IEnumerable<EstadosDTO>>(estados);
                return estadosDTO;
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
