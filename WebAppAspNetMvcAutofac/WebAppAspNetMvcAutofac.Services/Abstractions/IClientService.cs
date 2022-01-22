using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface IClientService
    {
        List<Client> GetEntities();
        Client Create();
        void Create(Client model);
        void Delete(int id);
        Client Edit(int id);
        void Edit(Client model);
        Document GetImage(int id, HttpServerUtilityBase server);
    }
}
