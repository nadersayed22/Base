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
        var hajjReqs = _hajjReqService.GetEntities(); // Fetch all entities
        return View(hajjReqs);
    }

    // GET: HajjReq/Create
    public ActionResult Create()
    {
        return View();
    }

  
    // POST: HajjReq/Create
    [HttpPost]
    public ActionResult Create(HajjReq hajjReq)
    {
        if (ModelState.IsValid)
        {
            _hajjReqService.CreateEntity(hajjReq);
            _hajjReqService.SaveEnitiy(); // Ensure method name is consistent
            return RedirectToAction("Index");
        }

        return View(hajjReq); // Return the model with validation errors
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
    [ValidateAntiForgeryToken] // Important to prevent CSRF attacks
    public ActionResult Edit(HajjReq hajjReq)
    {
        if (ModelState.IsValid)
        {
            _hajjReqService.Update(hajjReq);
            _hajjReqService.SaveEnitiy(); // Ensure method name is consistent
            return RedirectToAction("Index");
        }

        return View(hajjReq); // Return the model with validation errors
    }

    // GET: HajjReq/Delete/5
    public ActionResult Delete(int id)
    {
        var hajjReq = _hajjReqService.GetEntity(id);
        if (hajjReq == null)
        {
            return HttpNotFound();
        }

        return View(hajjReq); // Pass the entity to the view for confirmation
    }

    // POST: HajjReq/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken] // Important to prevent CSRF attacks
    public ActionResult DeleteConfirmed(int id)
    {
        var hajjReq = _hajjReqService.GetEntity(id);
        if (hajjReq != null)
        {
            _hajjReqService.Delete(hajjReq); // Use a delete method if available
            _hajjReqService.SaveEnitiy(); // Ensure method name is consistent
        }

        return RedirectToAction("Index");
    }

    // GET: HajjReq/Details/5
    public ActionResult Details(int id)
    {
        var hajjReq = _hajjReqService.GetEntity(id);
        if (hajjReq == null)
        {
            return HttpNotFound();
        }
        return View(hajjReq); // Return the entity to the details view
    }
}
