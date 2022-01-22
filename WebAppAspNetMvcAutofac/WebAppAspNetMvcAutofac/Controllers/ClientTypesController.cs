using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppAspNetMvcAutofac.DataModel;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac.Controllers
{
    public class ClientTypesController : Controller
    {
        private IClientTypeService _clientTypeService;
        public ClientTypesController(IClientTypeService clientTypeService)
        {
            _clientTypeService = clientTypeService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var clientTypes = _clientTypeService.GetEntities();

            return View(clientTypes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var clientType = _clientTypeService.Create();
            return View(clientType);
        }

        [HttpPost]
        public ActionResult Create(ClientType model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _clientTypeService.Create(model);

            return RedirectPermanent("/ClientTypes/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _clientTypeService.Delete(id);

            return RedirectPermanent("/ClientTypes/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var clientType = _clientTypeService.Edit(id);

            return View(clientType);
        }

        [HttpPost]
        public ActionResult Edit(ClientType model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _clientTypeService.Edit(model);

            return RedirectPermanent("/ClientTypes/Index");
        }

    }
}