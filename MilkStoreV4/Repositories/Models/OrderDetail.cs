﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
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

    public virtual Milk Order { get; set; }

    public virtual Order OrderNavigation { get; set; }
}