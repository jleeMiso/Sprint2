using System;

[Serializable]
public class Order
{
    public string TableID;
    public string OrderID;
    public string WaiterID;
    public string[] OrderedItems;
    public string[] Quantity;
    public string Total;
    public string Paid;

    public Order(string ti, string oi, string wi, string[] orderedItems, string[] qty, string total, string p)
    {
        TableID = ti;
        OrderID = oi;
        OrderedItems = orderedItems;
        Quantity = qty;
        Total = total;
        Paid = p;
    }
}

