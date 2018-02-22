using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DynamicDNAPerformanceReview.Controllers
{
    public class AccountController : Controller
    {
        public CMRSEntities2 DNA = new CMRSEntities2();
        // GET: Account
        public ActionResult Employees()
        {
            return View(DNA.UserAccounts.ToList()); //remove this not required
        }


        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount account)
        { using (DNA)
                {
                    DNA.UserAccounts.Add(account);

                    DNA.SaveChanges();
                }
                ModelState.Clear();
                //var user = User.Identity;
                //ViewBag.EmployeeName = user.Name;
                ViewBag.Message = account.EmployeeName + " " + " " + account.EmployeeSurname + " Succesfully registered.";

            
            return View("Register");
        }

        public ActionResult Login()
        {
            return View();
        }

        //just added this. at first it was HttpPost
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public ActionResult Login(UserAccount user, Management MAN, string returnurl)
        {
           
                using (DNA)
                {
                    string UUsername = user.Username;
                    string Password = user.Password;

                    //ADMIN.
                    string usen = MAN.Username;
                    string pass = MAN.Password;
                    //
                    var loggenIn = DNA.UserAccounts.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                    //ADMIN///////////////////////////////////////////////////////
                    var admin = DNA.Managements.FirstOrDefault(m => m.Username == MAN.Username && m.Password == MAN.Password);
                   

                    if (admin != null)
                    { //check if user exist
                        Session["ManagementID"] = MAN.ManagementID;
                    Session.Timeout = 30;
                    FormsAuthentication.SetAuthCookie(usen, true);
                        if (Url.IsLocalUrl(returnurl) && returnurl.Length > 1 && returnurl.StartsWith("/")
                            && !returnurl.StartsWith("//") && !returnurl.StartsWith("/\\"))


                        {
                            return Redirect(returnurl);
                        }
                        else
                        {
                            return RedirectToAction("AdminList", "Reviews");

                        }


                    }
                    ////////////////////////////////////////////////////////////////////
                    if (loggenIn != null)


                    { //check if user exist
                        Session["UserId"] = loggenIn.UserID;
                    Session.Timeout = 30;
                    FormsAuthentication.SetAuthCookie(UUsername, true);
                        if (Url.IsLocalUrl(returnurl) && returnurl.Length > 1 && returnurl.StartsWith("/")
                            && !returnurl.StartsWith("//") && !returnurl.StartsWith("/\\"))
                        {
                            return Redirect(returnurl);
                        }

                        else
                        {
                        //ViewBag.Message = user.EmployeeName + " " + user.EmployeeSurname;
                            return RedirectToAction("Home", "Reviews");

                        }


                    }
                    else
                    {
                        
                        ViewBag.Message = " Username or Password is Invalid";
                    }
            }

            // If we got this far, something failed, redisplay form
            return View(user);
        }


        public ActionResult LogOff()
        {

            Session["UserID"] = null;
            FormsAuthentication.SignOut();
            Session.Clear();  // This may not be needed -- but can't hurt
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}