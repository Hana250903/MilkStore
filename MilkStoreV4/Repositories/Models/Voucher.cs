using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Voucher
{
    public int VoucherId { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public double Discount { get; set; }

    public int Quantity { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
