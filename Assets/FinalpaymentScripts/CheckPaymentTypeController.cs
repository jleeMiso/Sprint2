using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

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

    private OrdersCollection ordersCollection;

    private List<Order> allOrdersFromTable;

    public decimal change = 0.00M;

    public void userToggle(string method)
    {
        paymentMethod = method;
    }

    public void OnClickPayment()
    {
        string amountReceived = AmountReceivedText.text.ToString();
        string totalPrice = TotalPrice.text.ToString();

        change = decimal.Parse(amountReceived) - decimal.Parse(totalPrice);

        using (StreamReader stream = new StreamReader("Assets/Orders.json"))
        {
            string json = stream.ReadToEnd();

            ordersCollection = JsonUtility.FromJson<OrdersCollection>(json);
        }

        if (change >= 0)
        {
            ChangeText.text = change.ToString();
            RemainingBalanceText.text = "0.00";

            ordersCollection.orders[1].Paid = "true";
            ordersCollection.orders[1].Total = "0.00";

            File.WriteAllText("Assets/Orders.json", JsonUtility.ToJson(ordersCollection));
        }
        else
        {
            ChangeText.text = "0.00";
            RemainingBalanceText.text = change.ToString();
        }

        AmountReceivedText.text = "";
        TotalPrice.text = Convert.ToString(change);
    }
}
