using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int MemberId { get; set; }

    public int? VoucherId { get; set; }

    public DateTime DateCreate { get; set; }

    public double Amount { get; set; }

    public int StatusId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual Status Status { get; set; } = null!;

    public virtual Voucher? Voucher { get; set; }
}
