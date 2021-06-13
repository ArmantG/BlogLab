﻿using System;
using System.Collections.Generic;

namespace BlogLab.Model.Blog
{
  public class PagedResults<T>
  {
    public IEnumerable<T> Items { get; set; }

    public int TotalCount { get; set; }
  }
}
