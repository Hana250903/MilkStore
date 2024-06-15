using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Milktype
{
    public int MilkTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Milk> Milk { get; set; } = new List<Milk>();
}
