using System;
using System.Collections.Generic;

namespace FootHub.Models;

public partial class BrandTable
{
    public int BId { get; set; }

    public string BName { get; set; }

    public int IsAvailable { get; set; }

    public virtual ICollection<ProductTable> ProductTables { get; set; } = new List<ProductTable>();
}
