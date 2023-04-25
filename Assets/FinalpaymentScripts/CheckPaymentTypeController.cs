using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPaymentTypeController : MonoBehaviour
{
    public InsertAmountController insertAmountController;
    public string paymentMethod = "";

    public void userToggle(string method)
    {
        print(method);
        paymentMethod = method;
    }

    public void OnClickPayment()
    {
        print(paymentMethod + " " + insertAmountController.AmountReceivedText.text + " !!!");
    }
}
