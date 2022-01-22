using WebAppAspNetMvcAutofac.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac.Controllers
{
    public class OrdersController : Controller
    {
        private IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var orders = _orderService.GetEntities();

            return View(orders);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var order = _orderService.Create();
            return View(order);
        }

        [HttpPost]
        public ActionResult Create(Order model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _orderService.Create(model);

            return RedirectPermanent("/Orders/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _orderService.Delete(id);

            return RedirectPermanent("/Orders/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var order = _orderService.Edit(id);

            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _orderService.Edit(model);

            return RedirectPermanent("/Orders/Index");
        }

    }
}