using Base.Controllers;
using Base.Model1;
using Base.Service.Interfaces;
using Base.Service.Services;
using System.Web.Mvc;

public class HajjReqController : BaseController
{
    private readonly IHajjReqService _hajjReqService;

    public HajjReqController(IHajjReqService hajjReqService)
    {
        _hajjReqService = hajjReqService;
    }

    // GET: HajjReq
    public ActionResult Index()
    {
        var hajjReqs = _hajjReqService.GetEntities();
        return View(hajjReqs);
    }

    // GET: HajjReq/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: HajjReq/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(HajjReq hajjReq)
    {
        if (ModelState.IsValid)
        {
            _hajjReqService.CreateEntity(hajjReq);
            _hajjReqService.SaveEnitiy(); // Save changes
            return RedirectToAction("Index");
        }

        return View(hajjReq);
    }

    // GET: HajjReq/Edit/5
    public ActionResult Edit(int id)
    {
        var hajjReq = _hajjReqService.GetEntity(id);
        if (hajjReq == null)
        {
            return HttpNotFound();
        }

        return View(hajjReq);
    }

    // POST: HajjReq/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(HajjReq hajjReq)
    {
        if (ModelState.IsValid)
        {
            _hajjReqService.Update(hajjReq);
            _hajjReqService.SaveEnitiy(); // Save changes
            return RedirectToAction("Index");
        }

        return View(hajjReq);
    }

    // GET: HajjReq/Delete/5
    public ActionResult Delete(int id)
    {
        var hajjReq = _hajjReqService.GetEntity(id);
        if (hajjReq == null)
        {
            return HttpNotFound();
        }

        return View(hajjReq);
    }

    // POST: HajjReq/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var hajjReq = _hajjReqService.GetEntity(id);
        if (hajjReq != null)
        {
            _hajjReqService.Update(hajjReq); // Update if any status change before deleting
            _hajjReqService.SaveEnitiy();
        }

        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        var hajjReq = _hajjReqService.GetEntity(id);
        if (hajjReq == null)
        {
            return HttpNotFound();
        }
        return View(hajjReq);
    }
}
