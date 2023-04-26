using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[Serializable]
public class CheckPaymentTypeController : MonoBehaviour
{
    public InsertAmountController insertAmountController;
    public string paymentMethod = "";

    [SerializeField]
    public Text TotalPrice;

    [SerializeField]
    public Text AmountReceivedText;

    [SerializeField]
    public Text ChangeText;

    [SerializeField]
    public Text RemainingBalanceText;

    [SerializeField]
    public Text AmountTextHelper;

    private OrdersCollection ordersCollection;

    private List<Order> allOrdersFromTable;

    private TableCollection tableCollection;

    public decimal change = 0.00M;

    public static string tableID = "";

    public void userToggle(string method)
    {
        paymentMethod = method;
    }

    public void OnClickPayment()
    {
        tableID = TableOnClick.selectedTable.tableId;

        string amountReceived = AmountReceivedText.text.ToString();
        string totalPrice = TotalPrice.text.ToString();

        change = decimal.Parse(amountReceived) - decimal.Parse(totalPrice);

        List<int> tableOrders = new List<int>();

        using (StreamReader stream = new StreamReader("Assets/Orders.json"))
        {
            string json = stream.ReadToEnd();

            ordersCollection = JsonUtility.FromJson<OrdersCollection>(json);

            for (int i = 0; i < ordersCollection.count(); i++)
            {
                if (ordersCollection.orders[i].TableID.Equals(TableOnClick.selectedTable.tableId))
                {
                    tableOrders.Add(i);
                }
            }
        }

        if (change.ToString().Equals("0.00"))
        {
            for (int i = 0; i < tableOrders.Count; i++)
            {
                ordersCollection.orders[i].Paid = "true";
                ordersCollection.orders[i].Total = "0.00";
            }
            ChangeText.text = change.ToString();
            RemainingBalanceText.text = "0.00";

            AmountReceivedText.text = "";

            TotalPrice.text = Convert.ToString(change);

            File.WriteAllText("Assets/Orders.json", JsonUtility.ToJson(ordersCollection));

            using (StreamReader stream = new StreamReader("Assets/Resources/table.json"))
            {
                string json = stream.ReadToEnd();

                tableCollection = JsonUtility.FromJson<TableCollection>(json);
            }

            for (int i = 0; i < tableCollection.tables.Length; i++)
            {
                if (tableCollection.tables[i].tableId.Equals(tableID))
                {
                    tableCollection.tables[i].status = "dirty";
                }
            }

            File.WriteAllText("Assets/Resources/table.json", JsonUtility.ToJson(tableCollection));
        }
        else
        {
            AmountTextHelper.text = "Enter the correct amount";
        }
    }

    public void onClickCancelPayment()
    {
        SceneManager.LoadScene("OrderScreen");
        ChangeText.text = "Try again";
        RemainingBalanceText.text = "Try again";
    }

    public void onClosePopup()
    {
        if (change.ToString().Equals("0.00"))
        {
            SceneManager.LoadScene("TableScene");
        }
    }
}
