using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Voucherstatus
{
    public int VoucherStatusId { get; set; }

    public string VoucherStatus1 { get; set; } = null!;

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
