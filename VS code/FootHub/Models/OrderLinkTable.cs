using System;
using System.Collections.Generic;

namespace FootHub.Models;

public partial class OrderLinkTable
{
    public int OrderLink { get; set; }

    public int OrderId { get; set; }

    public int UId { get; set; }

    public int PId { get; set; }

    public int Quantity { get; set; }

    public virtual OrderTable Order { get; set; }

    public virtual ProductTable PIdNavigation { get; set; }

    public virtual UserTable UIdNavigation { get; set; }
}
