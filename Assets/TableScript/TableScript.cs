using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[Serializable]
public class TableScript : MonoBehaviour
{
    [SerializeField]
    public Text GreetText;

    [SerializeField]
    public Button[] buttonGroup;

    private TableCollection tableCollection;

    private Table table;

    // Start is called before the first frame update
    void Start()
    {
        UserLogin userlogin = new UserLogin();
        SignedInWaiter sienedInWaiter = userlogin.getUserData();
        if (sienedInWaiter != null)
        {
            GreetText.text = "Hello " + sienedInWaiter.firstName + " " + sienedInWaiter.lastName;
        }

        using (StreamReader stream = new StreamReader("Assets/Resources/table.json"))
        {
            string json = stream.ReadToEnd();

            tableCollection = JsonUtility.FromJson<TableCollection>(json);
        }

        for (int i = 0; i < tableCollection.tables.Length; i++)
        {
            if (tableCollection.tables[i].status.Equals("vacant"))
            {
                buttonGroup[i].image.color = new Color32(0, 255, 40, 255);
            }
            else if (tableCollection.tables[i].status.Equals("occupied"))
            {
                buttonGroup[i].image.color = new Color32(255, 242, 0, 255);
            }
            else if (tableCollection.tables[i].status.Equals("dirty"))
            {
                buttonGroup[i].image.color = new Color32(255, 0, 20, 255);
            }
            else
            {
                buttonGroup[i].image.color = new Color32(255, 255, 255, 255);
            }
        }
    }
}


