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
    public class CitizenshipService : ICitizenshipService
    {
        private readonly Lazy<IRepository<Citizenship>> _citizenshipRepository;

        public CitizenshipService(Lazy<IRepository<Citizenship>> citizenshipRepository)
        {
            _citizenshipRepository = citizenshipRepository;
        }
        public List<Citizenship> GetEntities()
        {
            return _citizenshipRepository.Value.GetQuery().ToList();
        }

        public Citizenship Create()
        {
            return new Citizenship();
        }
        public void Create(Citizenship model)
        {
            _citizenshipRepository.Value.Add(model);
            _citizenshipRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var citizenship = _citizenshipRepository.Value.FirstOrDefault(x => x.Id == id);
            if (citizenship == null)
                throw new Exception("Citizenship not found");

            _citizenshipRepository.Value.Delete(citizenship);
            _citizenshipRepository.Value.SaveChanges();
        }
        public Citizenship Edit(int id)
        {
            var citizenship = _citizenshipRepository.Value.FirstOrDefault(x => x.Id == id);
            if (citizenship == null)
                throw new Exception("Citizenship not found");

            return citizenship;
        }
        public void Edit(Citizenship model)
        {
            var citizenship = _citizenshipRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (citizenship == null)
                throw new Exception("Citizenship not found");

            MappingCitizenship(model, citizenship);

            _citizenshipRepository.Value.Update(citizenship);
            _citizenshipRepository.Value.SaveChanges();
        }

        private void MappingCitizenship(Citizenship sourse, Citizenship destination)
        {
            destination.Name = sourse.Name;
            
        }
    }
}
