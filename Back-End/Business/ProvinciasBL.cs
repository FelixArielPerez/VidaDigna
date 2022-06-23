using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using Business.Interface;
using DataTransferObject;
using Repository;
using UnitOfWork;
using DataAccess.Entities;
using System.Transactions;

namespace Business
{
    public class ProvinciasBL:IProvinciasBL<ProvinciasDTO>
    {
        private ProvinciasRepository repo = null;
        private IUnitOfWorkFactory uowF = null;
        readonly IMapper mapperBase;

        public ProvinciasBL()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Provincias, ProvinciasDTO>().ReverseMap();
            });

            mapperBase = config.CreateMapper();
        }
        public IEnumerable<ProvinciasDTO> GetAll()
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new ProvinciasRepository(this.uowF.GetUnitOfWork());
                var element = repo.GetAll();
                var elementDTO = mapperBase.Map<IEnumerable<Provincias>, IEnumerable<ProvinciasDTO>>(element.ToList());
                return elementDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ProvinciasDTO> FindByIdProvincia(int idProvincia)
        {
            uowF = new TransactionScopeUnitOfWorkFactory();
            repo = new ProvinciasRepository(this.uowF.GetUnitOfWork());
            var element = repo.Find(x => x.IdProvincia == idProvincia);
            var elementDTO = mapperBase.Map<IEnumerable<Provincias>, IEnumerable<ProvinciasDTO>>(element);
            return elementDTO;
        }

        public ProvinciasDTO Single(object primaryKey)
        {
            uowF = new TransactionScopeUnitOfWorkFactory();
            repo = new ProvinciasRepository(this.uowF.GetUnitOfWork());
            var element = repo.Single(primaryKey);
            var elementDTO = mapperBase.Map<Provincias, ProvinciasDTO>(element);
            return elementDTO;
        }

        public ProvinciasDTO SingleOrDefault(object primaryKey)
        {
            uowF = new TransactionScopeUnitOfWorkFactory();
            repo = new ProvinciasRepository(this.uowF.GetUnitOfWork());
            var element = repo.SingleOrDefault(primaryKey);
            var elementDTO = mapperBase.Map<Provincias, ProvinciasDTO>(element);
            return elementDTO;
        }

        public bool Exists(object primaryKey)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByName(object primaryKey, object name)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProvinciasDTO entity)
        {
            throw new NotImplementedException();
        }

        public void InsertRange(IEnumerable<ProvinciasDTO> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(ProvinciasDTO entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<ProvinciasDTO> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProvinciasDTO entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<ProvinciasDTO> entities)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(IEnumerable<ProvinciasDTO> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProvinciasDTO> Find(string where, string orderby, int skip, int top, out int count)
        {
            throw new NotImplementedException();
        }
    }
}
