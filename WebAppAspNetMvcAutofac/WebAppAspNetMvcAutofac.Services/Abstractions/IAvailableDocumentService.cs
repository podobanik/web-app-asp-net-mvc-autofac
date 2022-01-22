using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface IAvailableDocumentService
    {
        List<AvailableDocument> GetEntities();
        AvailableDocument Create();
        void Create(AvailableDocument model);
        void Delete(int id);
        AvailableDocument Edit(int id);
        void Edit(AvailableDocument model);
    }
}
