using System.ComponentModel.DataAnnotations;

namespace TestBlog.Models
{
   public abstract class ViewModelBase
    {
      [Url]
      public string BannerUrl { get; set; }
      public string PageTitle { get; set; }
      public string PageSubtitle { get; set; }
   }
}
