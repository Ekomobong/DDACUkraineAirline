using DDACUkraineAirlines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DDACUkraineAirlines.Controllers
{
    public class HomeController : Controller
    {
        private DDACUkrainAirlinesEntities db = new DDACUkrainAirlinesEntities();
        private DDACUkrainAirlinesEntities1 db1 = new DDACUkrainAirlinesEntities1();

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Register(Registration reg)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(reg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        
                [HttpPost]
                [ValidateAntiForgeryToken]

                public ActionResult Login(Registration reg)
                {
                    if (ModelState.IsValid)
                    {
                        var details = (from userList in db.Registrations
                                       where userList.EmailAddress == reg.EmailAddress && userList.Password == reg.Password
                                       select new
                                       {
                                           userList.UserId,
                                           userList.EmailAddress,

                                       }).ToList();
                        if (details.FirstOrDefault() != null)
                        {
                            Session["Id"] = details.FirstOrDefault().UserId;
                            Session["Email"] = details.FirstOrDefault().EmailAddress;
                            return RedirectToAction("Welcome", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Credentials");
                    }
                    return View(reg);
                }

                public ActionResult Welcome()
                {
                    return View();
               }

                [HttpPost]
                [ValidateAntiForgeryToken]

                public ActionResult Welcome (Booking book)
        {
            if (ModelState.IsValid)
            {
                db1.Bookings.Add(book);
                db1.SaveChanges();
                return RedirectToAction("Payment");
            }
            return View();
        }

                public ActionResult Payment()
                {

                    return View(db1.Bookings.ToList());
                }

                public ActionResult Cancel(int? FlightID)
                {
                    if (FlightID == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Booking bookingDetails = db1.Bookings.Find(FlightID);
                    if (bookingDetails == null)
                    {
                        return HttpNotFound();
                    }
                   return View(bookingDetails);
                }

                [HttpPost, ActionName("Cancel")]
                [ValidateAntiForgeryToken]

                public ActionResult CancelConfirmed(int FlightID) 
                {
                    Booking bookingDetails = db1.Bookings.Find(FlightID);
                    db1.Bookings.Remove(bookingDetails);
                    db1.SaveChanges();
                    return RedirectToAction("Welcome");
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

                public ActionResult Pay()
                {
                    return View();
                }
            }
    }









