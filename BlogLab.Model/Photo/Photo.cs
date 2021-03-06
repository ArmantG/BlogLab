using System;

namespace BlogLab.Model.Photo
{
  public class Photo : PhotoCreate
  {
    public int PhotoId { get; set; }

    public int ApplicationUserId { get; set; }

    public DateTime PublishDate { get; set; }

    public DateTime UpdateDate { get; set; }
  }
}
