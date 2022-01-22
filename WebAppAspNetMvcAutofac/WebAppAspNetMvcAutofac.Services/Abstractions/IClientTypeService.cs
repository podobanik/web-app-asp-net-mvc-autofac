using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface IClientTypeService
    {
        List<ClientType> GetEntities();
        ClientType Create();
        void Create(ClientType model);
        void Delete(int id);
        ClientType Edit(int id);
        void Edit(ClientType model);
    }
}
