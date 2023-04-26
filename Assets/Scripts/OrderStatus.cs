using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OrderStatus : MonoBehaviour
{
    public GameObject Login;
    public GameObject TablePanel;
    public GameObject OrderStatusPanel;
    public Button ToLogin;
    public Button ToOrderStatus;

    public GameObject Parent;
    public Transform CurrentPos;
    public Vector3 WorkingPos;
    public TMP_Text[] CurrentOrders = new TMP_Text[30];
    public TMP_Text Template;
    private int CurrentOrderNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 temp3 = new Vector2(100, 450);
        WorkingPos = temp3;
        ToLogin.onClick.AddListener(LoadLogin);
        ToOrderStatus.onClick.AddListener(LoadTablePanel);
        //Testing code for order status
        /*
        AddOrder("1", " Cooking");
        AddOrder("2", " Cooking");
        AddOrder("3", " Cooking");
        AddOrder("4", " Done");
        AddOrder("5", " Cooking");
        AddOrder("6", " Cooking");
        AddOrder("7", " Cooking");
        AddOrder("8", " Cooking");
        AddOrder("9", " Cooking");
        AddOrder("10", " Cooking");
        AddOrder("11", " Cooking");
        AddOrder("12", " Cooking");
        AddOrder("13", " Cooking");
        AddOrder("14", " Done");
        AddOrder("15", " Cooking");
        AddOrder("16", " Cooking");
        AddOrder("17", " Cooking");
        AddOrder("18", " Cooking");
        AddOrder("19", " Cooking");
        AddOrder("20", " Cooking");
        AddOrder("21", " Cooking");
        AddOrder("22", " Cooking");
        AddOrder("23", " Done");
        AddOrder("24", " Cooking");
        AddOrder("25", " Cooking");
        AddOrder("26", " Cooking");
        AddOrder("27", " Cooking");
        AddOrder("28", " Cooking");
        AddOrder("29", " Cooking");
        AddOrder("30", " Cooking");
        */
    }

    // Update is called once per frame
    void Update()
    {
        //Test keys
        /*
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddOrder("0", " Done");
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            UpdateOrder("3", "Fin");
        }
        */
    }
    public void AddOrder(string orderID, string orderStatus)
    {
        if (CurrentOrderNum >= 29)
        {
            CurrentOrderNum = 0;
            Vector3 temp3 = new Vector2(100, 450);
            WorkingPos = temp3;
        }
        if (CurrentOrders[CurrentOrderNum] == null)
        {
            TMP_Text K = Instantiate(Template, new Vector2(WorkingPos.x, WorkingPos.y), Quaternion.identity);
            K.transform.SetParent(Parent.transform);
            K.transform.position = WorkingPos;
            K.text = orderID;
            K.text += orderStatus;
            Vector3 temp = new Vector2(200f, 0);
            WorkingPos += temp;
            if (CurrentOrderNum == 6 || CurrentOrderNum == 13 || CurrentOrderNum == 20 || CurrentOrderNum == 27)
            {
                Vector3 temp2 = new Vector2(0, -100);
                WorkingPos += temp2;
                Vector3 temp4 = new Vector2(100, WorkingPos.y);
                WorkingPos = temp4;
            }
            CurrentOrders[CurrentOrderNum] = K;
            CurrentOrderNum++;
        }
    }
    public void UpdateOrder(string orderID, string TextNew)
    {
        CurrentOrders[FindOrder(orderID)].text = orderID + TextNew;
    }
    int FindOrder(string orderID)
    {
        int orderIndex = 0;
        int ID = int.Parse(orderID);
        foreach(TMP_Text order in CurrentOrders)
        {
            if (order != null) 
            {
                if (order == CurrentOrders[ID])
                {
                    orderIndex = ID;
                    break;
                }
            }
        }
        return orderIndex;
    }
    void LoadLogin()
    {
        OrderStatusPanel.SetActive(false);
        Login.SetActive(true);
    }
    void LoadTablePanel()
    {
        OrderStatusPanel.SetActive(false);
        TablePanel.SetActive(true);
    }
}
