using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface ICitizenshipService
    {
        List<Citizenship> GetEntities();
        Citizenship Create();
        void Create(Citizenship model);
        void Delete(int id);
        Citizenship Edit(int id);
        void Edit(Citizenship model);
    }
}
