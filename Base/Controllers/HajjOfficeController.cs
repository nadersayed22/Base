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
        private readonly IUserService _userService;

        public HajjOfficeController(IHajjOfficeService hajjOfficeService, IUserService userService)
        {
            _hajjOfficeService = hajjOfficeService;
            _userService = userService;
        }

        // GET: HajjOffice
        public ActionResult Index()
        {
            var hajjOffices = _hajjOfficeService.GetEntities();
            return View(hajjOffices);
        }



        // GET: HajjOffice/Details/5
        public ActionResult Details(int id)
        {
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
            ViewBag.RepresentativeList = new SelectList(_userService.GetEntities(), "ID", "Name");
            return View();
        }

        // POST: HajjOffice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HajjOffice hajjOffice)
        {
            if (ModelState.IsValid)
            {
                _hajjOfficeService.CreateEntity(hajjOffice);
                _hajjOfficeService.SaveEnitiy(); 
                return RedirectToAction("Index");
            }

            ViewBag.RepresentativeList = new SelectList(_userService.GetEntities(), "ID", "Name", hajjOffice.OfficeRepresentativeID);
            return View(hajjOffice);
        }



        // GET: HajjOffice/Edit/5
        public ActionResult Edit(int id)
        {
            var hajjOffice = _hajjOfficeService.GetEntity(id);
            if (hajjOffice == null)
            {
                return HttpNotFound();
            }

            ViewBag.RepresentativeList = new SelectList(_userService.GetEntities(), "ID", "Name", hajjOffice.OfficeRepresentativeID);
            return View(hajjOffice);
        }

        // POST: HajjOffice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HajjOffice hajjOffice)
        {
            if (ModelState.IsValid)
            {
                _hajjOfficeService.Update(hajjOffice);
                _hajjOfficeService.SaveEnitiy(); 
                return RedirectToAction("Index");
            }

            ViewBag.RepresentativeList = new SelectList(_userService.GetEntities(), "ID", "Name", hajjOffice.OfficeRepresentativeID);
            return View(hajjOffice);
        }
        // GET: HajjOffice/Delete/5
        public ActionResult Delete(int id)
        {
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
            var hajjOffice = _hajjOfficeService.GetEntity(id);
            if (hajjOffice != null)
            {
                _hajjOfficeService.Delete(hajjOffice);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Search(string officeName)
        {
            Expression<Func<HajjOffice, bool>> condition = o => o.OfficeName.Contains(officeName);
            var filteredHajjOffices = _hajjOfficeService.Getmany(condition);

            return View("Index", filteredHajjOffices);
        }
    }
}
