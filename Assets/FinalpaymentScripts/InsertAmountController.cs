using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertAmountController : MonoBehaviour
{
    [SerializeField]
    public Text AmountReceivedText;

    public void OnClickEvent(string str)
    {
        AmountReceivedText.text += str;
    }

    public void DeleteLastDigit()
    {
        if (AmountReceivedText.text.Length > 0)
        {
            AmountReceivedText.text = AmountReceivedText.text.TrimEnd(AmountReceivedText.text[AmountReceivedText.text.Length - 1]);
        }
    }
}
