﻿using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Milk
{
    public int MilkId { get; set; }

    public string MilkName { get; set; } = null!;

    public int BrandId { get; set; }

    public int Capacity { get; set; }

    public int MilkTypeId { get; set; }

    public string AppropriateAge { get; set; } = null!;

    public string StorageInstructions { get; set; } = null!;

    public double Price { get; set; }

    public double Discount { get; set; }

    public virtual MilkType AppropriateAgeNavigation { get; set; } = null!;

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<MilkPicture> MilkPictures { get; set; } = new List<MilkPicture>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}