using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DynamicDNAPerformanceReview;
using Rotativa;
using System.IO;
using WebMatrix.Data;
using Ionic.Zip;
using System.IO.Compression;
using DynamicDNAPerformanceReview.Filtters;

namespace DynamicDNAPerformanceReview.Controllers
{/*[Authorize]*/
    //[HandleError]
    public class ReviewsController : Controller
    {
        private CMRSEntities2 db = new CMRSEntities2();

        // GET: Reviews
        [Authorize]
        public ActionResult UserList() //USERLIST
        {

            try
            {
                var userid = (int)Session["UserId"];
                //Session.Timeout = 30;
                var reviewTables = db.ReviewTables
                    .Where(u => u.fkEmployeeId == userid)
                    .Include(r => r.Management).Include(r => r.UserAccount).OrderBy(e=>e.DateOfReview);
                return View(reviewTables.ToList());
            }
            catch (Exception ex)

            {
                //throw ex;

                return View("UserList");

            }
        }

        

        public ActionResult blah()
        {
            return View();
        }

       


        public ActionResult Downloadpdf(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewTable reviewTable = db.ReviewTables.Find(id);
            if (reviewTable == null)
            {
                return HttpNotFound();
            }
            return View(reviewTable);
        }











        // GET: Reviews/Details/5
        [Authorize]
        public ActionResult UserDetails(int? id)
        {
            Session["Reviewid"] = id;
            Session["ManagementID"] = id; //Remove
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewTable reviewTable = db.ReviewTables.Find(id);
            if (reviewTable == null)
            {
                return HttpNotFound();
            }
            return View(reviewTable);
        }







        [Authorize]
        public ActionResult AdminDetails(int? id)
        {
            Session["Reviewid"] = id;
            Session["ManagementID"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewTable reviewTable = db.ReviewTables.Find(id);
            if (reviewTable == null)
            {
                return HttpNotFound();
            }
            return View(reviewTable);
        }










        // GET: Reviews/Create
        [Authorize]
        public ActionResult FillReview()
        {
          
            ViewBag.fkManagementID = new SelectList(db.Managements, "ManagementID", "Lastname");
            //ViewBag.fkEmployeeId = new SelectList(db.UserAccounts, "UserID", "EmployeeName");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want reto bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FillReview([Bind(Include = "ReviewID,fkManagementID,fkEmployeeId,RoleOnProject,ProjectEngagement,LineManager,DateOfReview,PeriodOfReview,proPeer,ProManagement,proAgreed,ExPeer,ExMan,ExAgreed,JudPeer,JudMan,JudAgreed,IntPeer,IntMan,IntAgreed,JobPeer,JobMan,JobAgreed,PassPeer,PassMan,PassAgreed,TeaPeer,TeaMan,TeaAgreed,GroPeer,GroMan,GroAgreed,OverallAverage,GeneralComments,prComments,ExComments,JuComments,intComments,JobComments,PassComments,TeaComments,GroComments,CareerPlans,ObjectivesNextPeriod,DueDate")] ReviewTable reviewTable)
        {
            if (ModelState.IsValid)
            {
                reviewTable.fkEmployeeId = Convert.ToInt32(Session["UserId"]);
                db.ReviewTables.Add(reviewTable);
                db.SaveChanges();
                return RedirectToAction("UserList");
            }
           
            ViewBag.fkManagementID = new SelectList(db.Managements, "ManagementID", "Lastname", reviewTable.fkManagementID);
            ViewBag.fkEmployeeId = new SelectList(db.UserAccounts, reviewTable.fkEmployeeId == reviewTable.UserAccount.UserID);
            ViewBag.Message = " Review succesfully submited.";
            return View(reviewTable);
        }

        // GET: Reviews/Edit/5
        [Authorize]
        public ActionResult UpdateReview(int? id) //Edit for manager
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewTable reviewTable = db.ReviewTables.Find(id);
            if (reviewTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkManagementID = new SelectList(db.Managements, "ManagementID", "Lastname", reviewTable.fkManagementID);
            ViewBag.fkEmployeeId = new SelectList(db.UserAccounts, "UserID", "EmployeeName", reviewTable.fkEmployeeId);
            return View(reviewTable);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateReview([Bind(Include = "ReviewID,fkManagementID,fkEmployeeId,RoleOnProject,ProjectEngagement,LineManager,DateOfReview,PeriodOfReview,proPeer,ProManagement,proAgreed,ExPeer,ExMan,ExAgreed,JudPeer,JudMan,JudAgreed,IntPeer,IntMan,IntAgreed,JobPeer,JobMan,JobAgreed,PassPeer,PassMan,PassAgreed,TeaPeer,TeaMan,TeaAgreed,GroPeer,GroMan,GroAgreed,OverallAverage,GeneralComments,prComments,ExComments,JuComments,intComments,JobComments,PassComments,TeaComments,GroComments,CareerPlans,ObjectivesNextPeriod,DueDate,OverallAVGman,OverallAVGAgreed")] ReviewTable reviewTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviewTable).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminList", "Reviews", "AdminList");
            }
            ViewBag.fkManagementID = new SelectList(db.Managements, "ManagementID", "Lastname", reviewTable.fkManagementID);
            ViewBag.fkEmployeeId = new SelectList(db.UserAccounts, "UserID", "EmployeeName", reviewTable.fkEmployeeId);
            return View(reviewTable);
        }

        // GET: Reviews/Delete/5
        [Authorize]
        public ActionResult RemoveReview(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewTable reviewTable = db.ReviewTables.Find(id);
            if (reviewTable == null)
            {
                return HttpNotFound();
            }
            return View(reviewTable);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("RemoveReview")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveConfirmed(int id)
        {
            ReviewTable reviewTable = db.ReviewTables.Find(id);
            db.ReviewTables.Remove(reviewTable);
            db.SaveChanges();
            return RedirectToAction("AdminList", "Reviews", "AdminList");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult ExportPDF(UserAccount users,   int id)
        {

            
            return new ActionAsPdf(
                           "Downloadpdf",
                           new { id = id }) 
            {


              

            FileName = User.Identity.Name + "Performance Review.pdf" , PageSize= Rotativa.Options.Size.A4, 
                /*SaveOnServerPath = @"~/Content",  */              CustomSwitches =
                    "--footer-center \"" +  DateTime.Now.Date.ToString("MM/dd/yyyy") + "  Page: [page]/[toPage]\"" + " --footer-line --footer-font-size \"9\" --footer-spacing 6 --footer-font-name \"calibri light\""



            };



        }



        //public ActionResult pdf( int id)
        //{


        //    var fileName = "Perf Review.pdf.pdf";
        //    var filePath = Path.Combine(Server.MapPath("/Downloadss"), fileName);

        //    return new ViewAsPdf("Index", new { id = id })
        //    {
        //        FileName = fileName,
        //        PageSize =Rotativa.Options.Size.A4,
        //        SaveOnServerPath = filePath
        //    };
        //}




        [HttpPost]
        public ActionResult ProcessForm(List<string> selectedfiles) //Proceses each pdf, selects
        {
            if (System.IO.File.Exists(Server.MapPath
                              ("~/zipped/Downloadss.zip")))
            {
                System.IO.File.Delete(Server.MapPath
                              ("~/zipped/Downloadss.zip"));
            }
            ZipArchive zip = System.IO.Compression.ZipFile.Open(Server.MapPath
                     ("~/zipped/Downloadss.zip"), ZipArchiveMode.Create);
            foreach (string file in selectedfiles)
            {
                zip.CreateEntryFromFile(Server.MapPath
                     ("~/Downloadss/" + file), file);
            }
            zip.Dispose();
            return File(Server.MapPath("~/zipped/Downloadss.zip"),
                      "application/zip", "Downloadss.zip");
        }

        [Authorize]
        public ActionResult Download()
        {

            //var dir = new System.IO.DirectoryInfo(Server.MapPath("~/WeeklyLogbooks/"));
            //System.IO.FileInfo[] fileNames = dir.GetFiles("*.*"); List<string> items = new List<string>();
            //foreach (var file in fileNames)
            //{
            //    items.Add(file.Name);
            //}
            //return View(items);


            string[] files = Directory.GetFiles(
                 Server.MapPath("~/Downloadss"));
            List<string> downloads = new List<string>();
            foreach (string file in files)
            {
                downloads.Add(Path.GetFileName(file));
            }
            return View(downloads);
        }

        [Authorize]

        public ActionResult Home()
        {
            return View();
        }


        public ActionResult Modal()
        {
            return View();
        }


        public ActionResult Hell(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "UserID" ? "date_desc" : "UserID";
            var UserAccounts = from s in db.UserAccounts
                           select s;


          
            if (!string.IsNullOrEmpty(searchString))
            {
                UserAccounts = UserAccounts.Where(s => s.EmployeeName.Contains(searchString)
                                       || s.EmployeeName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    UserAccounts = UserAccounts.OrderByDescending(s => s.EmployeeSurname);
                    break;
                case "UserID":
                    UserAccounts = UserAccounts.OrderBy(s => s.UserID);
                    break;
                case "date_desc":
                    UserAccounts = UserAccounts.OrderByDescending(s => s.UserID);
                    break;
                default:
                    UserAccounts = UserAccounts.OrderBy(s => s.EmployeeSurname);
                    break;
            }

            return View(db.UserAccounts.ToList());
        }







        [Authorize]
        [AllowAnonymous]
        [Authorize]
        public ActionResult AdminList( string SortOrder, string SearchString )
        {
            ViewBag.NameSortParameter = string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            ViewBag.datesortParameter = SortOrder == "Date" ? "DateOfReview" : "Date";

            var Employees = from s in db.UserAccounts select s;

            var reviews = from s in db.ReviewTables select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                Employees = Employees.Where(s => s.EmployeeName.Contains(SearchString) || s.EmployeeSurname.Contains(SearchString));
            }
            switch (SortOrder)
            {
                case "name_desc":
                    Employees = Employees.OrderByDescending(s => s.EmployeeSurname);
                    break;
                case "Date":
                    reviews = reviews.OrderBy(s => s.DateOfReview);
                    break;
                case "date_desc":
                    reviews = reviews.OrderByDescending(s => s.DateOfReview);
                    break;
                default:
                    Employees = Employees.OrderBy(s => s.EmployeeSurname);
                    break;
            }

            if (Session["ManagementID"] == null)
            {
                return Redirect("~/Account/Login");
            }
         
            var manID = (int)Session["ManagementID"];
          
            var reviewTables = db.ReviewTables.Where(u => u.fkManagementID == u.Management.ManagementID).Include(r => r.Management).Include(r => r.UserAccount)/*.OrderBy(a=>a.DateOfReview)*/;
            return View(reviewTables.ToList());
        }

        
        [Authorize]
        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        public ActionResult AdminList(FormCollection form)
        {
            MyFilter filter = new MyFilter();
            string year = Request.Form["Year"];
            string quater = Request.Form["Quater"];
            string name = Request.Form["Name"];
            if (string.IsNullOrEmpty(name))            
                name = "0";
            if (string.IsNullOrEmpty(year))
                year = "0";
            
             
            if (string.IsNullOrEmpty(quater) && Convert.ToInt32(name)==0 && (string.IsNullOrEmpty(year)!= true))
            {
                return View("MyAdminList", filter.ByYear(Convert.ToInt32(year)));
            }
            else if ((string.IsNullOrEmpty(quater)!=true) && Convert.ToInt32(name) == 0 && year == "0")
            {
                return View("MyAdminList", filter.ByQauter(quater));
            }
            else if (string.IsNullOrEmpty(quater) && Convert.ToInt32(name) != 0 && (year == "0"))
            {
                return View("MyAdminList", filter.ByName(Convert.ToInt32(name)));
            }
            else if (Convert.ToInt32(name) == 0 && (string.IsNullOrEmpty(quater)!= true) && (year != "0"))
            {
                return View("MyAdminList", filter.ByYearQuater(year, quater));
            }
            else if ((string.IsNullOrEmpty(quater) != true) && (year != "0") && (Convert.ToInt32(name) != 0) )
            {
                return View("MyAdminList", filter.ByYearQuaterName(year, quater, Convert.ToInt32(name)));
            }
            else if ((string.IsNullOrEmpty(quater)!= true )&& Convert.ToInt32(name) == 0 && (year!="0" ) )
            {
                return View("MyAdminList", filter.ByYearQuaterName(year, quater, Convert.ToInt32(name)));
            }
            else if ((string.IsNullOrEmpty(year)!= true && Convert.ToInt32(name) != 0 && string.IsNullOrEmpty(quater)))
            {
                return View("MyAdminList", filter.ByYearName(year, Convert.ToInt32(name)));
            }
            else if (string.IsNullOrEmpty(quater)!=true && Convert.ToInt32(name)!=0&&year=="0")
            {
                return View("MyAdminList", filter.ByQuaterName(quater, Convert.ToInt32(name)));
            }
            else
            {
                return RedirectToAction("MyAdminList");
            }
            //return RedirectToAction("MyAdminList");
        }

        public ActionResult MyAdminList()
        {
            return View(db.ReviewTables.ToList());
        }



        public ActionResult Growth()
        {
            return View();
        }



        public ActionResult Chart()
        {
            ViewBag.UserId = Session["UserId"];
            //ViewBag.ManId = Session["ManagementID"];
            return View();
        }



        public ActionResult CreateFolder()//This is for creating folders based on date
        {
            string Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");
            if (!Directory.Exists("I:\\test\\final test\\snaps\\" + Todaysdate))
            {
                Directory.CreateDirectory("I:\\test\\final test\\snaps\\" + Todaysdate);
            }
            return View();
        }


    }
}
