using System;
using System.Collections.Generic;

namespace FootHub.Models;

public partial class ProductType
{
    public int TId { get; set; }

    public string TName { get; set; }

    public int IsAvailable { get; set; }

    public virtual ICollection<ProductTable> ProductTables { get; set; } = new List<ProductTable>();
}
