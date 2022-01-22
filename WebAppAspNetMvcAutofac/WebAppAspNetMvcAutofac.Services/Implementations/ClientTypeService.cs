using Common.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public class ClientTypeService : IClientTypeService
    {
        private readonly Lazy<IRepository<ClientType>> _clientTypeRepository;

        public ClientTypeService(Lazy<IRepository<ClientType>> clientTypeRepository)
        {
            _clientTypeRepository = clientTypeRepository;
        }
        public List<ClientType> GetEntities()
        {
            return _clientTypeRepository.Value.GetQuery().ToList();
        }

        public ClientType Create()
        {
            return new ClientType();
        }
        public void Create(ClientType model)
        {
            _clientTypeRepository.Value.Add(model);
            _clientTypeRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var clientType = _clientTypeRepository.Value.FirstOrDefault(x => x.Id == id);
            if (clientType == null)
                throw new Exception("ClientType not found");

            _clientTypeRepository.Value.Delete(clientType);
            _clientTypeRepository.Value.SaveChanges();
        }
        public ClientType Edit(int id)
        {
            var clientType = _clientTypeRepository.Value.FirstOrDefault(x => x.Id == id);
            if (clientType == null)
                throw new Exception("ClientType not found");

            return clientType;
        }
        public void Edit(ClientType model)
        {
            var clientType = _clientTypeRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (clientType == null)
                throw new Exception("ClientType not found");

            MappingClientType(model, clientType);

            _clientTypeRepository.Value.Update(clientType);
            _clientTypeRepository.Value.SaveChanges();
        }

        private void MappingClientType(ClientType sourse, ClientType destination)
        {
            destination.Name = sourse.Name;
        }
    }
}
