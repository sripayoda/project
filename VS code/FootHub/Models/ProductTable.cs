using System;
using System.Collections.Generic;

namespace FootHub.Models;

public partial class ProductTable
{
    public int PId { get; set; }

    public string PName { get; set; }

    public string PDesc { get; set; }

    public int Size { get; set; }

    public int Price { get; set; }

    public int TotalStock { get; set; }

    public string PImage { get; set; }

    public int OId { get; set; }

    public int TId { get; set; }

    public int BId { get; set; }

    public string CategoryName { get; set; }

    public virtual BrandTable BIdNavigation { get; set; }

    public virtual ICollection<CartTable> CartTables { get; set; } = new List<CartTable>();

    public virtual OcassionTable OIdNavigation { get; set; }

    public virtual ICollection<OrderLinkTable> OrderLinkTables { get; set; } = new List<OrderLinkTable>();

    public virtual ProductType TIdNavigation { get; set; }
}
