using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public int UserId { get; set; }

    public string Desciption { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
