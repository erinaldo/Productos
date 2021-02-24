using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Effort.Filters;
using Effort.Models;
using Effort.Utils;

namespace Effort.Controllers
{

    public class AccountController : Controller
    {

        EffortEntities db = new EffortEntities();
        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Equipo login = db.Equipo.SingleOrDefault(e => e.idEquipo == model.UserName);
                if (login != null)
                {
                    if (HashPass.ValidatePassword(model.Password, login.contrasena))
                    {
                        Session.Add("Login", login);
                        Equipo loginSession = (Equipo)Session["Login"];
                        System.Diagnostics.Debug.WriteLine("ROLE " + loginSession.perfil);
                        return RedirectToLocal(returnUrl);
                    }
                }
                
            }

            model.Message = "El nombre de usuario o la contraseña especificados son incorrectos.";
          
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            Session.Remove("Login");
            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public ActionResult NotAccess()
        {
            return View();
        }

        #region Aplicaciones auxiliares
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Proyecto");
            }
        }

        #endregion
    }
}
