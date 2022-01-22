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
    public class AvailableDocumentService : IAvailableDocumentService
    {
        private readonly Lazy<IRepository<AvailableDocument>> _availableDocumentRepository;

        public AvailableDocumentService(Lazy<IRepository<AvailableDocument>> availableDocumentRepository)
        {
            _availableDocumentRepository = availableDocumentRepository;
        }
        public List<AvailableDocument> GetEntities()
        {
            return _availableDocumentRepository.Value.GetQuery().ToList();
        }

        public AvailableDocument Create()
        {
            return new AvailableDocument();
        }
        public void Create(AvailableDocument model)
        {
            _availableDocumentRepository.Value.Add(model);
            _availableDocumentRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var availableDocument = _availableDocumentRepository.Value.FirstOrDefault(x => x.Id == id);
            if (availableDocument == null)
                throw new Exception("AvailableDocument not found");

            _availableDocumentRepository.Value.Delete(availableDocument);
            _availableDocumentRepository.Value.SaveChanges();
        }
        public AvailableDocument Edit(int id)
        {
            var availableDocument = _availableDocumentRepository.Value.FirstOrDefault(x => x.Id == id);
            if (availableDocument == null)
                throw new Exception("AvailableDocument not found");

            return availableDocument;
        }
        public void Edit(AvailableDocument model)
        {
            var availableDocument = _availableDocumentRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (availableDocument == null)
                throw new Exception("AvailableDocument not found");

            MappingAvailableDocument(model, availableDocument);

            _availableDocumentRepository.Value.Update(availableDocument);
            _availableDocumentRepository.Value.SaveChanges();
        }

        private void MappingAvailableDocument(AvailableDocument sourse, AvailableDocument destination)
        {
            destination.Name = sourse.Name;
        }
    }
}
