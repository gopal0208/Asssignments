using System;
using System.Collections.Generic;

namespace ProductApi.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Descrip { get; set; }

    public int? Price { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public decimal? Rating { get; set; }

    public int? Stock { get; set; }

    public string? Brand { get; set; }

    public int CategoryId { get; set; }

    public string? Thumbnail { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Image> Images { get; } = new List<Image>();
}