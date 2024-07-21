using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Voucher
{
    public int VoucherId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public double Discount { get; set; }

    public int Quantity { get; set; }

    public int VoucherStatusId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Voucherstatus VoucherStatus { get; set; } = null!;
}
