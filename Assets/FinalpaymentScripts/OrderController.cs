using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class OrderController : MonoBehaviour
{
    [SerializeField]
    public Text TableIdText;

    [SerializeField]
    public Text ItemsText;

    [SerializeField]
    public Text totalPrice;

    private OrdersCollection ordersCollection;

    private List<Order> allOrdersFromTable;

    public OrderController()
    {
        using (StreamReader stream = new StreamReader("Assets/Orders.json"))
        {
            string json = stream.ReadToEnd();

            ordersCollection = JsonUtility.FromJson<OrdersCollection>(json);

            allOrdersFromTable = ordersCollection.filterOrders(TableOnClick.selectedTable.tableId);
        }
    }

    void Update()
    {
        decimal total = 0.00M;
        string items = "";
        if (allOrdersFromTable.Count > 0)
        {
            allOrdersFromTable.ForEach(o =>
            {
                int i = 0;
                decimal t = decimal.Parse(o.Total);
                total += t;
                foreach (string item in o.OrderedItems)
                {
                    items += item + "   " + o.Quantity[i] + "\n";
                    i++;
                }
            });
            TableIdText.text = TableOnClick.selectedTable.tableId;
            totalPrice.text = Convert.ToString(total);
            ItemsText.text = items;
        }
    }

    public void returnHome()
    {
        SceneManager.LoadScene("TableScene");
    }

    public void returnTable()
    {
        SceneManager.LoadScene("OrderScreen");
    }
}