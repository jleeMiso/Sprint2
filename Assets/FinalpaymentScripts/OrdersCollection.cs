using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class OrdersCollection
{
    public Order[] orders;

    public List<Order> filterOrders(string tableID)
    {
        List<Order> filteredOrders = new List<Order>();

        foreach(Order order in orders)
        {
            if (order.TableID.Equals(tableID))
            {
                filteredOrders.Add(order);
            }
        }
        return filteredOrders;
    }

    public int count()
    {
        int count = 0;
        foreach (Order order in orders)
        {
            count++;
        }
        return count;
    }
}
