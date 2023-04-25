using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class OrdersCollection
{
    public Order[] orders;

    public List<Order> filteredOrders = new List<Order>();

    public List<Order> filterOrders(string tableID)
    {
        foreach(Order order in orders)
        {
            if (order.TableID.Equals(tableID))
            {
                filteredOrders.Add(order);
            }
        }
        return filteredOrders;
    }
}
