using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int MilkId { get; set; }

    public int Quantity { get; set; }

    public double Total { get; set; }

    public virtual Milk Order { get; set; } = null!;

    public virtual Order OrderNavigation { get; set; } = null!;
}
