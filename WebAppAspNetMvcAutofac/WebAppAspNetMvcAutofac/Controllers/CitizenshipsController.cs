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
    public class CitizenshipsController : Controller
    {
        private ICitizenshipService _citizenshipService;
        public CitizenshipsController(ICitizenshipService citizenshipService)
        {
            _citizenshipService = citizenshipService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var citizenships = _citizenshipService.GetEntities().ToList();

            return View(citizenships);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var citizenship = _citizenshipService.Create();
            return View(citizenship);
        }

        [HttpPost]
        public ActionResult Create(Citizenship model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _citizenshipService.Create(model);

            return RedirectPermanent("/Citizenships/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _citizenshipService.Delete(id);

            return RedirectPermanent("/Citizenships/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var citizenship = _citizenshipService.Edit(id);

            return View(citizenship);
        }

        [HttpPost]
        public ActionResult Edit(Citizenship model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _citizenshipService.Edit(model);

            return RedirectPermanent("/Citizenships/Index");
        }
    }
}