using System;

[Serializable]
public class Order
{
    public string TableID;
    public string OrderID;
    public string WaiterID;
    public string[] OrderedItems;
    public string Total;
    public string Paid;
}

