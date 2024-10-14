using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Base.Model1;
using Base.Service.Interfaces;
using Base.Service.Services;

namespace Base.Controllers
{
    public class HajjOfficeController : BaseController
    {
        private readonly IHajjOfficeService _hajjOfficeService;
        private readonly IUserService _userService;
        private readonly IOfficeReqService _fficeReqService;
        private readonly IHajjReqService _hajjReqService;

        public HajjOfficeController(IHajjOfficeService hajjOfficeService, IUserService userService, IOfficeReqService fficeReqService, IHajjReqService hajjReqService)
        {
            _hajjOfficeService = hajjOfficeService;
            _userService = userService;
            _fficeReqService = fficeReqService;
            _hajjReqService = hajjReqService;
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
        //[ValidateAntiForgeryToken]
        public ActionResult Create(HajjOffice hajjOffice)
        {
            if (ModelState.IsValid)
            {
                _hajjOfficeService.CreateEntity(hajjOffice);
                _hajjOfficeService.SaveEnitiy();
                return RedirectToAction("Index");
            }

            // In case of validation errors, repopulate the dropdown list with the selected value
            ViewBag.RepresentativeList = new SelectList(_userService.GetEntities(), "ID", "Name", hajjOffice.OfficeRepresentativeID);

            return View(hajjOffice);
        }

        [Route("Edit/{id}")]

        public ActionResult Edit(int id)
        {
            var hajjOffice = _hajjOfficeService.GetEntity(id);
            if (hajjOffice == null)
            {
                // Log the ID or perform other diagnostics
                return HttpNotFound();
            }
            ViewBag.RepresentativeList = new SelectList(_userService.GetEntities(), "ID", "Name", hajjOffice.OfficeRepresentativeID);
            return View(hajjOffice);
        }


        // GET: HajjOffice/Edit/5
        [HttpPost]
        public ActionResult Edit(HajjOffice hajjOffice)
        {
            if (ModelState.IsValid)
            {
                // Update and save the entity
                _hajjOfficeService.Update(hajjOffice);
                _hajjOfficeService.SaveEnitiy(); // Correct method name

                return RedirectToAction("Index");
            }

            // Repopulate the dropdown in case of validation failure
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
        [HttpGet]
        public ActionResult CreateOfficeReq()
        {
            // Fetch the dropdown data for Hajj offices and requests
            ViewBag.HajjOffices = new SelectList(_hajjOfficeService.GetEntities(), "ID", "OfficeName");
            ViewBag.HajjRequests = new SelectList(_hajjReqService.GetEntities(), "ID", "Name");

            // Return the empty OfficeReq object to be filled in the form
            return PartialView("OfficeRequest", new OfficeReq());
        }

        [HttpPost]
        public ActionResult CreateOfficeReq(OfficeReq officeReq)
        {
            if (ModelState.IsValid)
            {
                _fficeReqService.CreateEntity(officeReq);  // Create the new OfficeReq
                _fficeReqService.SaveEnitiy();  // Save changes to the database
                return Json(new { success = true });  // Return success response
            }

            // Repopulate dropdowns for validation failure scenarios
            ViewBag.HajjRequests = new SelectList(_hajjReqService.GetEntities(), "ID", "Name");
            ViewBag.HajjOffices = new SelectList(_hajjOfficeService.GetEntities(), "ID", "OfficeName");

            // Return partial view with validation errors
            return PartialView("OfficeRequest", officeReq);
        }


        //[HttpPost]
        //public ActionResult CreateOfficeReq(OfficeReq officeReq)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _fficeReqService.CreateEntity(officeReq); // Create the new OfficeReq
        //        _fficeReqService.SaveEnitiy(); // Save changes to the database

        //        // Return success as a JSON response (for AJAX submission)
        //        return Json(new { success = true });
        //    }

        //    // If ModelState is invalid, repopulate the dropdowns for the partial view
        //    ViewBag.HajjRequests = new SelectList(_hajjReqService.GetEntities(), "ID", "RequestName");
        //    ViewBag.HajjOffice = new SelectList(_hajjOfficeService.GetEntities(), "ID", "OfficeName");

        //    // Return partial view with validation errors (for AJAX submission)
        //    return PartialView("OfficeRequest", officeReq);
        //}


    }
}
