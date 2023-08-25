using System;
using System.Collections.Generic;

namespace FootHub.Models;

public partial class CartTable
{
    public int CartId { get; set; }

    public int UId { get; set; }

    public int PId { get; set; }

    public virtual ProductTable PIdNavigation { get; set; }

    public virtual UserTable UIdNavigation { get; set; }
}
