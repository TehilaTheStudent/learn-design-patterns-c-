namespace RealisticDependencies.Models;

using System;
using System.Collections.Generic;

public class Order
{
    public DateTime TimeOfPurchase { get; set; }
    public decimal TotalPrice { get; set; }
    public List<string> LineItems { get; set; }
}
