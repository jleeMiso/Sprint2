using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TableOnClick : MonoBehaviour
{
    public static SelectedTable selectedTable;

    public void tableOnclick(string tableId)
    {
        selectedTable = new SelectedTable(tableId);

        SceneManager.LoadScene("OrderScreen");
    }

    public void logout()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
