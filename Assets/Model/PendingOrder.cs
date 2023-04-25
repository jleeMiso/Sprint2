using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendingOrder
{
    public string Item { get; set; }

    public string Quantity { get; set; }

    public PendingOrder(string item, string qty)
    {
        Item = item;
        Quantity = qty;
    }
}
