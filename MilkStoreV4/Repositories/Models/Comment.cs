﻿using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int MemberId { get; set; }

    public DateOnly DateCreate { get; set; }

    public string Content { get; set; } = null!;

    public string Picture { get; set; } = null!;

    public double Rate { get; set; }

    public int MilkId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual Milk Milk { get; set; } = null!;
}