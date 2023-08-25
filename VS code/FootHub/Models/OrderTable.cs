using System;
using System.Collections.Generic;

namespace FootHub.Models;

public partial class OrderTable
{
    public int OrderId { get; set; }

    public int UId { get; set; }

    public string UName { get; set; }

    public string UAddress { get; set; }

    public int Price { get; set; }

    public string OrderDate { get; set; }

    public virtual ICollection<OrderLinkTable> OrderLinkTables { get; set; } = new List<OrderLinkTable>();

    public virtual UserTable UIdNavigation { get; set; }
}
