using AutoMapper;
using Base.Model;
using Base.Models;
using Base.Service.Interfaces;
using Base.Service.Services;
using Base.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using StingRay.Utility.CommonModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Base.Controllers
{
	public class AccountController : BaseController
	{
		private readonly IUserService userService;

		public AccountController(IUserService userService)
        {
			this.userService = userService;
		}

        [HttpGet]
		[AllowAnonymous]
		public ActionResult Login()
		{
			return View("Login");
		}

		public ActionResult LogOff()
		{
			Session["CurrentUser"] = null;

			var ctx = Request.GetOwinContext();
			var authenticationManager = ctx.Authentication;
			authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
			return View("Login");
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult Login(LoginModel model, string returnUrl)
		{
			try
			{
				userService.SaveEnitiy();

				if (!string.IsNullOrWhiteSpace(model.Password))
				{
					var password = StingRay.Utility.CommonOperation.SecurityOperation.TripleDES.Encrypt(model.Password, false);
					var tmp = userService.Getmany(m => m.Email == model.Email && m.Password == password);

					var User = tmp.Count() == 0 ? new Model.UserModel() : tmp.First();
					
					if (tmp.Count() == 0)
					{
						model.ReturnURL = returnUrl;
						using (StreamWriter sr = new StreamWriter(Server.MapPath("~/logfile.txt"), true))
						{
							ModelState.AddModelError("", "Wrong Email Address or Password .");
							sr.WriteLine("Wrong Email Address or Password." + "[" + DateTime.Now.ToShortDateString() + "]");
						}
						return View();
					}
					else
					{
						var claims = new List<Claim>();

						claims.Add(new Claim(ClaimTypes.NameIdentifier, User.ID.ToString()));
						claims.Add(new Claim("_Email", User.Email));
						claims.Add(new Claim("DisplayName", User.Name));
						claims.Add(new Claim("UserType", User.UserType.ToString()));

						var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

						var ctx = Request.GetOwinContext();
						var authenticationManager = ctx.Authentication;
						authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, id);

						return RedirectToAction("Index", "Home");
					}
				}
				else
				{
					using (StreamWriter sr = new StreamWriter(Server.MapPath("~/logfile.txt"), true))
					{
						sr.WriteLine("Not Valid User");
						sr.WriteLine("");
					}
				}
			}

			catch (Exception ex)
			{
				model.ReturnURL = returnUrl;
				using (StreamWriter sr = new StreamWriter(Server.MapPath("~/logfile.txt"), true))
				{
					sr.WriteLine(ex.Message);
					sr.WriteLine("");
				}
				return View();
			}
			return View();

		}

	}
}