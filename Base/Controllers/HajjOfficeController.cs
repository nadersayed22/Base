using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Base.Model1;
using Base.Service.Interfaces;

namespace Base.Controllers
{
    public class HajjOfficeController : BaseController
    {
        private readonly IHajjOfficeService _hajjOfficeService;

        public HajjOfficeController(IHajjOfficeService hajjOfficeService)
        {
            _hajjOfficeService = hajjOfficeService;
        }

        // GET: HajjOffice
        public ActionResult Index()
        {
            // Fetch all HajjOffice entities and pass them to the view
            var hajjOffices = _hajjOfficeService.GetEntities();
            return View(hajjOffices);
        }

        // GET: HajjOffice/Details/5
        public ActionResult Details(int id)
        {
            // Fetch a single HajjOffice entity by ID and pass it to the view
            var hajjOffice = _hajjOfficeService.GetEntity(id);
            if (hajjOffice == null)
            {
                return HttpNotFound();
            }
            return View(hajjOffice);
        }

        // GET: HajjOffice/Create
        public ActionResult Create()
        {
            // Render the create form
            return View();
        }

        // POST: HajjOffice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HajjOffice hajjOffice)
        {
            if (ModelState.IsValid)
            {
                // Create a new HajjOffice entity
                _hajjOfficeService.CreateEntity(hajjOffice);
                return RedirectToAction("Index");
            }

            // If the model is not valid, return the same view with validation errors
            return View(hajjOffice);
        }

        // GET: HajjOffice/Edit/5
        public ActionResult Edit(int id)
        {
            // Fetch the HajjOffice entity to be edited
            var hajjOffice = _hajjOfficeService.GetEntity(id);
            if (hajjOffice == null)
            {
                return HttpNotFound();
            }
            return View(hajjOffice);
        }

        // POST: HajjOffice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HajjOffice hajjOffice)
        {
            if (ModelState.IsValid)
            {
                // Update the HajjOffice entity
                _hajjOfficeService.Update(hajjOffice);
                return RedirectToAction("Index");
            }

            // If the model is not valid, return the same view with validation errors
            return View(hajjOffice);
        }

        // GET: HajjOffice/Delete/5
        public ActionResult Delete(int id)
        {
            // Fetch the HajjOffice entity to be deleted
            var hajjOffice = _hajjOfficeService.GetEntity(id);
            if (hajjOffice == null)
            {
                return HttpNotFound();
            }
            return View(hajjOffice);
        }

        // POST: HajjOffice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Fetch the entity and delete it
            var hajjOffice = _hajjOfficeService.GetEntity(id);
            if (hajjOffice != null)
            {
                // You would implement a delete method in your service/repository
                _hajjOfficeService.Delete(hajjOffice);
            }

            return RedirectToAction("Index");
        }

        // You can also add a search functionality using the GetMany method in the service
        public ActionResult Search(string officeName)
        {
            Expression<Func<HajjOffice, bool>> condition = o => o.OfficeName.Contains(officeName);
            var filteredHajjOffices = _hajjOfficeService.Getmany(condition);

            return View("Index", filteredHajjOffices);
        }
    }
}
