using System;
using System.Collections.Generic;

namespace ProductApi.Models;

public partial class Image
{
    public string ImageLink { get; set; } = null!;

    public int Id { get; set; }

    public virtual Product IdNavigation { get; set; } = null!;
}