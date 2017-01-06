using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestBlog.Models;

namespace TestBlog.Controllers
{
   public class HomeController : Controller
   {
      private ApplicationDbContext db = new ApplicationDbContext();

      //GET: Posts Index
      [HttpGet]
      public ActionResult Index()
      {
         return View();
      }

      [HttpGet]
      public PartialViewResult PostsIndexPartial(int? page)
      {
         
         int pageSize = 3;
         int pageNumber = (page ?? 1);

         return PartialView("~/Views/Home/_PostsIndexPartial.cshtml", db.Posts.ToList().OrderByDescending(p => p.Created).ToPagedList(pageNumber, pageSize));

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

      protected override void Dispose(bool disposing)
      {
         base.Dispose(disposing);
      }
   }
}