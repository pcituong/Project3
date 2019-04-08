using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Base.Controllers
{
    public class accountController : Controller
    {
        private employee_managementEntities db = new employee_managementEntities();
        // GET: account


        [HttpGet]
        [ActionName("Login")]
        public ActionResult getLogin(Admin usr = null)
        {
            if (ModelState.IsValid)
            {
                var u = db.Admins.Where(i => i.Name == usr.Name && i.Password == usr.Password).ToList().Count();
              
                
                    if (u > 0)
                    {
                        FormsAuthentication.SetAuthCookie(usr.Name,false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mật khẩu không đúng");
                    }
                
            }
            return View(usr);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
      
    }
}