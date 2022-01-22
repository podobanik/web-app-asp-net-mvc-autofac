using WebAppAspNetMvcAutofac.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac.Controllers
{
    public class ClientsController : Controller
    {
        
        private IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var clients = _clientService.GetEntities();

            return View(clients);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var client = _clientService.Create();
            return View(client);
        }

        [HttpPost]
        public ActionResult Create(Client model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _clientService.Create(model);

            return RedirectPermanent("/Clients/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _clientService.Delete(id);

            return RedirectPermanent("/Clients/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var client = _clientService.Edit(id);

            return View(client);
        }

        [HttpPost]
        public ActionResult Edit(Client model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _clientService.Edit(model);

            return RedirectPermanent("/Clients/Index");
        }



        [HttpGet]
        public ActionResult GetImage(int id)
        {
            var image = _clientService.GetImage(id, Server);

            return File(new MemoryStream(image.Data), image.ContentType);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var client = _clientService.Edit(id);

            return View(client);
        }
    }
}