using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public int UserId { get; set; }

    public string? Desciption { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;
}
