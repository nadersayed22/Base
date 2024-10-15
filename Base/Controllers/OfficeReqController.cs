using Base.Model1;
using Base.Service.Interfaces;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace Base.Controllers
{
    public class OfficeReqController : BaseController
    {
        private readonly IOfficeReqService _officeReqService;
        private readonly IHajjOfficeService _hajjOfficeService;
        
        private readonly IHajjReqService _hajjReqService;
        public OfficeReqController(IOfficeReqService officeReqService, IHajjOfficeService hajjOfficeService, IHajjReqService hajjReqService)
        {
            _officeReqService = officeReqService;
            _hajjOfficeService = hajjOfficeService;
            
            _hajjReqService = hajjReqService;
        }

        // GET: OfficeReq
        public ActionResult Index()
        {
            var officeReqs = _officeReqService.GetAllOfficeReqs("HajjOffice", "HajjReq"); // Include related entities
      

            return View(officeReqs);
        }

     
       
        // GET: OfficeReq/Edit/5
        public ActionResult Edit(int id)
        {
            var officeReq = _officeReqService.Getmany(x=>x.ID == id).FirstOrDefault(); // Get the specific OfficeReq
            if (officeReq == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeList = _hajjOfficeService.GetEntities().ToList();
            ViewBag.ReqList = _hajjReqService.GetEntities().ToList();
            return View(officeReq);
        }

        // POST: OfficeReq/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OfficeReq officeReq)
        {
            if (id != officeReq.ID)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _officeReqService.Update(officeReq);
                    _officeReqService.SaveEnitiy(); // Save changes after updating
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_officeReqService.Getmany(x=>x.ID == officeReq.ID).FirstOrDefault() != null)
                    {
                        return HttpNotFound();
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }
            ViewBag.OfficeList = _hajjOfficeService.GetEntities().ToList();
            ViewBag.ReqList = _hajjReqService.GetEntities().ToList();
            return View(officeReq);
        }

        // GET: OfficeReq/Details/5
        public ActionResult Details(int id)
        {
            var officeReq = _officeReqService.GetAllOfficeReqs("HajjOffice", "HajjReq")
                .FirstOrDefault(o => o.ID == id);
            if (officeReq == null)
            {
                return HttpNotFound();
            }
            return View(officeReq);
        }

        // GET: OfficeReq/Delete/5
        public ActionResult Delete(int id)
        {
            var officeReq = _officeReqService.Getmany(x => x.ID == id).FirstOrDefault(); // Get the specific OfficeReq

            if (officeReq == null)
            {
                return HttpNotFound();
            }
            return View(officeReq);
        }

        // POST: OfficeReq/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var officeReq = _officeReqService.Getmany(x => x.ID == id).FirstOrDefault(); // Get the specific OfficeReq

            if (officeReq != null)
            {
                _officeReqService.Delete(officeReq);
                _officeReqService.GetEntities(); // Save changes after deletion
            }
            return RedirectToAction("Index");
        }
    }
}
