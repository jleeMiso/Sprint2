using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class UserVali : MonoBehaviour
{
    public GameObject LoginScreen;
    public GameObject TableStatusPanel;
    public GameObject Username;
    public InputField Use;
    public InputField Passer;
    public string User;
    public GameObject Password;
    public string Pass;
    public TMP_Text LoginErrorMessage;
    public Button self;
    public int iter = 0;
    string[] files = Directory.GetFiles("Assets/Profiles/");
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Button>();
        self.onClick.AddListener(OnSubmit);
        Use = Username.GetComponent<InputField>();
        //Username.text = "Test";
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void assignUsername(string s)
    {
        User = Use.text;
    }
    public void assignPassword(string s)
    {
        Pass = Passer.text;
    }
    void OnSubmit() 
    {
        foreach(string c in files)
        {
            StreamReader sr = new StreamReader(files[iter]);
            //string looksie = sr.ReadLine();
            if (files[iter].Contains("meta") == false)
            {
                if (sr.ReadLine() == User)
                {
                    if (sr.ReadLine() == Pass)
                    {
                        //Do anything related to loading next scene here
                        LoginErrorMessage.text = "Success!";
                        LoginScreen.SetActive(false);
                        TableStatusPanel.SetActive(true);
                    }
                    else { LoginErrorMessage.text = "Login Fail!"; }
                }
            }
            iter++;
        }
        iter = 0;
    }
}
