using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Orderdetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int MilkId { get; set; }

    public int Quantity { get; set; }

    public double Total { get; set; }

    public virtual Milk Milk { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
