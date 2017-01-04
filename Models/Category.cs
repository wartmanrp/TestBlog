using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlog.Models
{
    public class Category
    {
      public Category()
      {
         this.Posts = new HashSet<Post>();
      }
      public int Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public DateTimeOffset Created { get; set; }
      public DateTimeOffset? Modified { get; set; }
      public bool Deleted { get; set; }

      public virtual ICollection<Post> Posts { get; set; }
   }
}
