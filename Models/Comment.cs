using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestBlog.Models
{
    public class Comment
    {
      public Comment()
      {
         this.Comments = new HashSet<Comment>();
      }
      public int Id { get; set; }
      public int PostId { get; set; }
      public int AuthorId { get; set; }
      public int EditorId { get; set; }
      public int? ParentCommentId { get; set; }
      public DateTimeOffset Created { get; set; }
      public DateTimeOffset? Modified { get; set; }
      public bool Deleted { get; set; }
      [AllowHtml]
      public string Body { get; set; }

      public virtual Post Post { get; set; }
      public virtual ApplicationUser Author { get; set; }
      public virtual ApplicationUser Editor { get; set; }
      public virtual Comment ParentComment { get; set; }
      public virtual  ICollection<Comment> Comments { get; set; }
   }
}
