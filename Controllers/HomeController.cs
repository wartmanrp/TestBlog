using Microsoft.AspNet.Identity;
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

      [Authorize]
      [HttpGet]
      public ActionResult CreateEditPost(int? postId)
      {         
         if (postId != null)
         {
            var model = db.Posts.Find(postId);           
            return View(model);
         }
         else
         {
            return View();
         }
      }

      //TODO test this
      [Authorize]
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult SavePost(Post post)
      {
         if (ModelState.IsValid)
         {
            if (post.Id > 0)
            {
               //TODO test modified timestamp
               post.Modified = DateTimeOffset.Now;
               db.Posts.Attach(post);
            } else
            {
               string userId = User.Identity.GetUserId();
               post.Author = db.Users.FirstOrDefault(u => u.Id == userId);
               post.Created = DateTimeOffset.Now;
               SaveCategory(post.Category);

               db.Posts.Add(post);
            }



            db.SaveChanges();


         } else
         {
            return View("CreateEditPost", post.Id);
         }

         return RedirectToAction("Index");
      }

      [Authorize]
      private void SaveCategory(string category)
      {
         var parsedCategory = category.ToLower();
         if (!db.Categories.Any(c => c.Name == parsedCategory))
         {
            db.Categories.Add(new Category
            {
               Name = category,
               Created = DateTimeOffset.Now
            });

            db.SaveChanges();
         }
      }


      //Static pages//
      public ActionResult About()
      {
         return View();
      }

      public ActionResult Contact()
      {
         return View();
      }

      protected override void Dispose(bool disposing)
      {
         base.Dispose(disposing);
      }
   }
}