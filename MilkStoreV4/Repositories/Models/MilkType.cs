﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class MilkType
{
    public int MilkTypeId { get; set; }

    public string TypeName { get; set; } = string.Empty;

    public virtual ICollection<Milk> Milk { get; set; } = new List<Milk>();
}