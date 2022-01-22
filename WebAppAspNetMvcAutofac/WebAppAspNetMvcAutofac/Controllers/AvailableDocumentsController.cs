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
    public class AvailableDocumentsController : Controller
    {

        private IAvailableDocumentService _availableDocumentService;
        public AvailableDocumentsController(IAvailableDocumentService availableDocumentService)
        {
            _availableDocumentService = availableDocumentService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var availableDocuments = _availableDocumentService.GetEntities();

            return View(availableDocuments);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var availableDocument = _availableDocumentService.Create();
            return View(availableDocument);
        }

        [HttpPost]
        public ActionResult Create(AvailableDocument model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _availableDocumentService.Create(model);

            return RedirectPermanent("/AvailableDocuments/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _availableDocumentService.Delete(id);

            return RedirectPermanent("/AvailableDocuments/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var availableDocument = _availableDocumentService.Edit(id);

            return View(availableDocument);
        }

        [HttpPost]
        public ActionResult Edit(AvailableDocument model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _availableDocumentService.Edit(model);

            return RedirectPermanent("/AvailableDocuments/Index");
        }
    }
}