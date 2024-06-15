using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Milkpicture
{
    public int MilkPictureId { get; set; }

    public int MilkId { get; set; }

    public string Picture { get; set; } = null!;

    public virtual Milk Milk { get; set; } = null!;
}
