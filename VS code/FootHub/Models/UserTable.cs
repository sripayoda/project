using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FootHub.Models;

public partial class UserTable
{
    [JsonIgnore]
    public int UId { get; set; }

    public string UName { get; set; }

    public string UEmail { get; set; }

    public string UPassword { get; set; }

    public string UPhone { get; set; }

    public string URole { get; set; }

    [JsonIgnore]
    public virtual ICollection<CartTable> CartTables { get; set; } = new List<CartTable>();

    [JsonIgnore]
    public virtual ICollection<OrderLinkTable> OrderLinkTables { get; set; } = new List<OrderLinkTable>();

    [JsonIgnore]
    public virtual ICollection<OrderTable> OrderTables { get; set; } = new List<OrderTable>();
}
