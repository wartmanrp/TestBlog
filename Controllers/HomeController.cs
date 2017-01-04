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
      public ActionResult Index()
      {
         PostIndexViewModel result = new PostIndexViewModel();
         result.PageTitle = "Test";
         result.PageTitle = "This is a test";
         result.BannerUrl = "~/TestBlog/startbootstrap/img/home-bg.jpg";
         return View(result);
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