using System;
using System.Collections.Generic;

namespace FootHub.Models;

public partial class OcassionTable
{
    public int OId { get; set; }

    public string OName { get; set; }

    public int IsAvailable { get; set; }

    public virtual ICollection<ProductTable> ProductTables { get; set; } = new List<ProductTable>();
}
