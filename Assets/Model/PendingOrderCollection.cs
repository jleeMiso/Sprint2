using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendingOrderCollection
{
    public List<string> ItemsCollection = new List<string>();
    public List<string> QuantityCollection = new List<string>();

    public PendingOrderCollection()
    {
    }

    public void AddItem(string name, string qty)
    {
        ItemsCollection.Add(name);
        QuantityCollection.Add(qty);
    }
}
