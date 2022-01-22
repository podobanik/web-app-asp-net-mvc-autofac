using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public interface IOrderService
    {
        List<Order> GetEntities();
        Order Create();
        void Create(Order model);
        void Delete(int id);
        Order Edit(int id);
        void Edit(Order model);
    }
}
