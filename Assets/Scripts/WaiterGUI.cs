using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//[Serializable]
public class WaiterGUI : MonoBehaviour
{
    public Button Table;
    public string ID;
    public string status = "open";
    // Start is called before the first frame update
    void Start()
    {
        Table = GetComponent<Button>();
        //Table.onClick.AddListener(OnButtonClick);
        Table.GetComponent<Image>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        LoadTableStatus();
        OnButtonClick();
    }
    void OnButtonClick()
    {
        switch (status)
        {
            case "open":
                Table.GetComponent<Image>().color = Color.green;
                break;
            case "occupied":
                Table.GetComponent<Image>().color = Color.yellow;
                break;
            case "dirty":
                Table.GetComponent<Image>().color = Color.red;
                break;
        }
    }
    void LoadTableStatus()
    {
        StreamReader sr = new StreamReader("Assets/jsonTables/"+ID+".txt");
        status = sr.ReadLine();
        sr.Close();
    }
    public void SetTableStatus(string set)
    {
        StreamWriter sw = new StreamWriter("Assets/jsonTables/" + ID + ".txt");
        sw.WriteLine(set);
        sw.Close();
    }
    /*
    void OnButtonClick()
    {
        if (Table.GetComponent<Image>().color == Color.green)
        {
            Table.GetComponent<Image>().color = Color.yellow;
        }
        else if (Table.GetComponent<Image>().color == Color.yellow)
        {
            Table.GetComponent<Image>().color = Color.red;
        }
        else Table.GetComponent<Image>().color = Color.green;
    }
    */
}
