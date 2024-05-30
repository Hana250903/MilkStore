using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int MemberId { get; set; }

    public int VoucherId { get; set; }

    public DateOnly DateCreate { get; set; }

    public double Amount { get; set; }

    public string OrderStatus { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Voucher Voucher { get; set; } = null!;
}
