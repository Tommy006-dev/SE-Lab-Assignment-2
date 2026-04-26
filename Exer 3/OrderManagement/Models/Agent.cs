using System;
using System.Collections.Generic;

namespace OrderManagement.Models;

public partial class Agent
{
    public int AgentId { get; set; }

    public string AgentName { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
