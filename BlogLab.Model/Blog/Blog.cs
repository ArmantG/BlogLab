﻿using System;
namespace BlogLab.Model.Blog
{
  public class Blog : blogCreate
  {
    public string Username { get; set; }

    public int ApplicationUserId { get; set; }

    public DateTime PublishDate { get; set; }

    public DateTime UpdateDate { get; set; }


  }
}
