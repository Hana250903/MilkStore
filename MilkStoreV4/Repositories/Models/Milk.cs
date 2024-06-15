using System;
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

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Milktype MilkType { get; set; } = null!;

    public virtual ICollection<Milkpicture> Milkpictures { get; set; } = new List<Milkpicture>();

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
