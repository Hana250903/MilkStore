using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class MilkType
{
    public string MilkTypeId { get; set; } = null!;

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Milk> Milk { get; set; } = new List<Milk>();
}
