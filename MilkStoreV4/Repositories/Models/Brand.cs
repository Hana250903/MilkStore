using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public string? Picture { get; set; }

    public virtual ICollection<Milk> Milk { get; set; } = new List<Milk>();
}
