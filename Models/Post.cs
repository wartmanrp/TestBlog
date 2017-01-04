using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestBlog.Models
{
    public class Post
    {
      public Post()
      {
         this.Comments = new HashSet<Comment>();
         this.Categories = new HashSet<Category>();
      }

      public int Id { get; set; }
      public DateTimeOffset Created { get; set; }
      public DateTimeOffset? Modified { get; set; }
      public string Title { get; set; }

      [AllowHtml]
      public string Body { get; set; }
      public string MediaUrl { get; set; }
      public bool Published { get; set; }
      public bool Deleted { get; set; }


      public virtual ICollection<Category> Categories { get; private set; }
      public virtual ICollection<Comment> Comments { get; private set; }
   }
}
