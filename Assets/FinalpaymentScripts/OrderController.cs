using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;

[Serializable]
public class OrderController : MonoBehaviour
{
    [SerializeField]
    public Text TableIdText;

    [SerializeField]
    public Text ItemsText;

    private OrdersCollection ordersCollection;

    private List<Order> allOrdersFromTable;

    public OrderController()
    {
        using (StreamReader stream = new StreamReader("Assets/Orders.json"))
        {
            string json = stream.ReadToEnd();
            //print(json);
            ordersCollection = JsonUtility.FromJson<OrdersCollection>(json);

            allOrdersFromTable = ordersCollection.filterOrders("T1");
        }

        //print(allOrdersFromTable[0].TableID + " table id");

        //foreach (Order o in allOrdersFromTable)
        //{
        //    print(o.OrderedItems + " ordered items");
        //    print(o.Total + " total");
        //}
    }

    void Update()
    {
        TableIdText.text = allOrdersFromTable[0].TableID;
        Console.WriteLine(allOrdersFromTable.ToString());
    }
}