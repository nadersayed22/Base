using AutoMapper;
using Base.Model;
using Base.Service.Interfaces;
using Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Base.Controllers
{
    public class HomeController : BaseController
	{
        private readonly IUserService BaseService;
        public HomeController(IUserService BaseService)
        {
            this.BaseService = BaseService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}