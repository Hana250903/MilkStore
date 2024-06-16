using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Commentpicture
{
    public int CommentPictureId { get; set; }

    public int CommentId { get; set; }

    public string Picture { get; set; } = null!;

    public virtual Comment Comment { get; set; } = null!;
}
