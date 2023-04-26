using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaiterTest : MonoBehaviour
{
    public GameObject Login;
    public GameObject TablePanel;
    public GameObject OrderStatusPanel;
    public Button ToLogin;
    public Button ToOrderStatus;
    public GameObject[] Tables;
    public GameObject self;
    //private int iter = 0;
    // Start is called before the first frame update
    void Start()
    {
        ToLogin.onClick.AddListener(LoadLogin);
        ToOrderStatus.onClick.AddListener(LoadOrderStatus);
        /*
        foreach(Transform child in transform)
        {
            Tables[iter] = child.gameObject;
            ++iter;
        }
        Tables[0].GetComponent<WaiterGUI>().SetTableStatus("dirty");
        */
    }
    void LoadLogin()
    {
        TablePanel.SetActive(false);
        Login.SetActive(true);
    }
    void LoadOrderStatus()
    {
        TablePanel.SetActive(false);
        OrderStatusPanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
