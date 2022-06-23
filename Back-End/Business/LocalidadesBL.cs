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
    public class LocalidadesBL: ILocalidadesBL<LocalidadesDTO>
    {
        private LocalidadesRepository repo = null;
        private IUnitOfWorkFactory uowF = null;
        readonly IMapper mapperBase;

        public LocalidadesBL()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Localidades, LocalidadesDTO>().ReverseMap();
            });

            mapperBase = config.CreateMapper();
        }
        public IEnumerable<LocalidadesDTO> GetAll()
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new LocalidadesRepository(uowF.GetUnitOfWork());
                IEnumerable<Localidades> resultSet = repo.GetAll();
                IEnumerable<LocalidadesDTO> localidadesDTO = mapperBase.Map<IEnumerable<Localidades>, IEnumerable<LocalidadesDTO>>(resultSet);

                return localidadesDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        
        public IEnumerable<LocalidadesDTO> GetAllByIdProvincia(int idProvincia)
        {
            uowF = new TransactionScopeUnitOfWorkFactory();
            repo = new LocalidadesRepository(this.uowF.GetUnitOfWork());
            var element = repo.Find(x => x.IdProvincia == idProvincia);
            var elementDTO = mapperBase.Map<IEnumerable<Localidades>, IEnumerable<LocalidadesDTO>>(element);
            return elementDTO;
        }
        public IEnumerable<LocalidadesDTO> FindByIdProvincia(int idProvincia)
        {
            try
            {
                uowF = new TransactionScopeUnitOfWorkFactory();
                repo = new LocalidadesRepository(this.uowF.GetUnitOfWork());
                var element = repo.Find(x => x.IdProvincia == idProvincia);
                var elementDTO = mapperBase.Map<IEnumerable<Localidades>, IEnumerable<LocalidadesDTO>>(element);
                return elementDTO;
            }
            catch (Exception) {
                throw;
            }
        }

        public IEnumerable<LocalidadesDTO> FindByIdlocalidad(int idLocalidad)
        {
            uowF = new TransactionScopeUnitOfWorkFactory();
            repo = new LocalidadesRepository(this.uowF.GetUnitOfWork());
            var element = repo.Find(x => x.IdLocalidad == idLocalidad);
            var elementDTO = mapperBase.Map<IEnumerable<Localidades>, IEnumerable<LocalidadesDTO>>(element);
            return elementDTO;
        }

        public LocalidadesDTO Single(object primaryKey)
        {
            uowF = new TransactionScopeUnitOfWorkFactory();
            repo = new LocalidadesRepository(this.uowF.GetUnitOfWork());
            var element = repo.Single(primaryKey);
            var elementDTO = mapperBase.Map<Localidades, LocalidadesDTO>(element);
            return elementDTO;
        }

        public LocalidadesDTO SingleOrDefault(object primaryKey)
        {
            uowF = new TransactionScopeUnitOfWorkFactory();
            repo = new LocalidadesRepository(this.uowF.GetUnitOfWork());
            var element = repo.SingleOrDefault(primaryKey);
            var elementDTO = mapperBase.Map<Localidades, LocalidadesDTO>(element);
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

        public void Insert(LocalidadesDTO entity)
        {
            throw new NotImplementedException();
        }

        public void InsertRange(IEnumerable<LocalidadesDTO> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(LocalidadesDTO entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<LocalidadesDTO> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(LocalidadesDTO entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<LocalidadesDTO> entities)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(IEnumerable<LocalidadesDTO> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocalidadesDTO> Find(string where, string orderby, int skip, int top, out int count)
        {
            throw new NotImplementedException();
        }
    }
}
