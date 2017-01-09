using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

      [Required]
      public string Title { get; set; }

      [Required]
      public string Subtitle { get; set; }

      [Required]
      public string Category { get; set; }

      public virtual ApplicationUser Author { get; set; }
      
      [AllowHtml]
      public string Body { get; set; }
      public string MediaUrl { get; set; }
      public bool Published { get; set; }
      public bool Deleted { get; set; }


      public virtual ICollection<Category> Categories { get; private set; }
      public virtual ICollection<Comment> Comments { get; private set; }
   }
}
