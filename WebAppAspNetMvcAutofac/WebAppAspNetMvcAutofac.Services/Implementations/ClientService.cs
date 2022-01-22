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
    public class ClientService: IClientService
    {
        private readonly string _key = "123456Qq";
        private readonly Lazy<IRepository<Client>> _clientRepository;
        private readonly Lazy<IRepository<AvailableDocument>> _availableDocumentRepository;
        private readonly Lazy<IRepository<Order>> _orderRepository;
        private readonly Lazy<IRepository<Citizenship>> _citizenshipRepository;
        private readonly Lazy<IRepository<ClientType>> _clientTypeRepository;
        private readonly Lazy<IRepository<Document>> _documentRepository;

        public ClientService(Lazy<IRepository<Client>> clientRepository,
            Lazy<IRepository<AvailableDocument>> availableDocumentRepository,
            Lazy<IRepository<Order>> orderRepository,
            Lazy<IRepository<Citizenship>> citizenshipRepository,
            Lazy<IRepository<ClientType>> clientTypeRepository,
            Lazy<IRepository<Document>> documentRepository)
        {
            _clientRepository = clientRepository;
            _availableDocumentRepository = availableDocumentRepository;
            _orderRepository = orderRepository;
            _citizenshipRepository = citizenshipRepository;
            _clientTypeRepository = clientTypeRepository;
            _documentRepository = documentRepository;
        }
        public List<Client> GetEntities()
        {
            return _clientRepository.Value.GetQuery().ToList();
        }

        public Client Create()
        {
            return new Client();
        }
        public void Create(Client model)
        {
            

            if (model.DocumentFile != null)
            {
                var data = new byte[model.DocumentFile.ContentLength];
                model.DocumentFile.InputStream.Read(data, 0, model.DocumentFile.ContentLength);

                model.Documents = new Document()
                {
                    Guid = Guid.NewGuid(),
                    DateChanged = DateTime.Now,
                    Data = data,
                    ContentType = model.DocumentFile.ContentType,
                    FileName = model.DocumentFile.FileName
                };
            }

            if (model.OrderIds != null && model.OrderIds.Any())
            {
                var order = _orderRepository.Value.GetQuery().Where(s => model.OrderIds.Contains(s.Id)).ToList();
                model.Orders = order;
            }

            if (model.AvailableDocumentIds != null && model.AvailableDocumentIds.Any())
            {
                var availableDocument = _availableDocumentRepository.Value.GetQuery().Where(s => model.AvailableDocumentIds.Contains(s.Id)).ToList();
                model.AvailableDocuments = availableDocument;
            }

            if (model.CitizenshipId != null && model.CitizenshipId.Any())
            {
                var citizenship = _citizenshipRepository.Value.GetQuery().Where(s => model.CitizenshipId.Contains(s.Id)).ToList();
                model.Citizenships = citizenship;
            }
            if (model.ClientTypeIds != null && model.ClientTypeIds.Any())
            {
                var clientType = _clientTypeRepository.Value.GetQuery().Where(s => model.ClientTypeIds.Contains(s.Id)).ToList();
                model.ClientTypes = clientType;
            }


            _clientRepository.Value.Add(model);
            _clientRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var client = _clientRepository.Value.FirstOrDefault(x => x.Id == id);
            if (client == null)
                throw new Exception("Client not found");

            _clientRepository.Value.Delete(client);
            _clientRepository.Value.SaveChanges();
        }
        public Client Edit(int id)
        {
            var client = _clientRepository.Value.FirstOrDefault(x => x.Id == id);
            if (client == null)
                throw new Exception("Client not found");

            return client;
        }
        public void Edit(Client model)
        {
            var client = _clientRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (client == null)
                throw new Exception("Client not found");

            if (model.Key != _key)
                throw new Exception("Ключ для создания/изменения записи указан не верно");


            MappingClient(model, client);

            _clientRepository.Value.Update(client);
            _clientRepository.Value.SaveChanges();
        }
        public Document GetImage(int id, HttpServerUtilityBase server)
        {
            var image = _documentRepository.Value.FirstOrDefault(x => x.Id == id);
            if (image == null)
            {
                FileStream fs = System.IO.File.OpenRead(server.MapPath(@"~/Content/Images/not-foto.png"));
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                fs.Close();

                image = new Document()
                {
                    ContentType = "image/jpeg",
                    Data = fileData
                };
            }

            return image;
        }



        private void MappingClient(Client sourse, Client destination)
        {
            destination.Name = sourse.Name;
            destination.Surname = sourse.Surname;
            destination.Age = sourse.Age;
            destination.Birthday = sourse.Birthday;
            destination.Gender = sourse.Gender;
            destination.IsArchive = sourse.IsArchive;
            destination.Reviews = sourse.Reviews;
            destination.Key = sourse.Key;                   //из-за Required

            if (destination.Orders != null)
                destination.Orders.Clear();

            if (sourse.OrderIds != null && sourse.OrderIds.Any())
                destination.Orders = _orderRepository.Value.GetQuery().Where(s => sourse.OrderIds.Contains(s.Id)).ToList();

            if (destination.AvailableDocuments != null)
                destination.AvailableDocuments.Clear();

            if (sourse.AvailableDocumentIds != null && sourse.AvailableDocumentIds.Any())
                destination.AvailableDocuments = _availableDocumentRepository.Value.GetQuery().Where(s => sourse.AvailableDocumentIds.Contains(s.Id)).ToList();

            if (destination.Citizenships != null)
                destination.Citizenships.Clear();

            if (sourse.CitizenshipId != null && sourse.CitizenshipId.Any())
                destination.Citizenships = _citizenshipRepository.Value.GetQuery().Where(s => sourse.CitizenshipId.Contains(s.Id)).ToList();

            if (destination.ClientTypes != null)
                destination.ClientTypes.Clear();

            if (sourse.ClientTypeIds != null && sourse.ClientTypeIds.Any())
                destination.ClientTypes = _clientTypeRepository.Value.GetQuery().Where(s => sourse.ClientTypeIds.Contains(s.Id)).ToList();


            if (sourse.DocumentFile != null)
            {
                var image = _documentRepository.Value.FirstOrDefault(x => x.Id == sourse.Id);
                if (image != null)
                {
                    _documentRepository.Value.Delete(image);
                    _documentRepository.Value.SaveChanges();
                }
                   

                var data = new byte[sourse.DocumentFile.ContentLength];
                sourse.DocumentFile.InputStream.Read(data, 0, sourse.DocumentFile.ContentLength);

                destination.Documents = new Document()
                {
                    Guid = Guid.NewGuid(),
                    DateChanged = DateTime.Now,
                    Data = data,
                    ContentType = sourse.DocumentFile.ContentType,
                    FileName = sourse.DocumentFile.FileName
                };
            }
        }
    }
}
