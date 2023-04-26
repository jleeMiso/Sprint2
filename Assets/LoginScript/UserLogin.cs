using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[Serializable]
public class UserLogin : MonoBehaviour
{
    [SerializeField]
    public InputField UserId;

    [SerializeField]
    public InputField password;

    [SerializeField]
    public Text UserLoginHelper;

    private WaiterCollection waiterCollection;

    private List<Waiter> waiter;

    public static SignedInWaiter signedInWaiter;

    public void onClickLogin()
    {
        string loggedInUser = "";
        int ind = 0;
        //Waiter loggedInUser = null;
        using (StreamReader stream = new StreamReader("Assets/Resources/Waiter.json"))
        {
            string json = stream.ReadToEnd();

            waiterCollection = JsonUtility.FromJson<WaiterCollection>(json);
        }

        for(int i = 0; i < waiterCollection.waiters.Length; i++)
        {
            if (UserId.text.Equals(waiterCollection.waiters[i].username) && password.text.Equals(waiterCollection.waiters[i].password))
            {
                loggedInUser = waiterCollection.waiters[i].username;
                ind = i;
            }
        }

        if (loggedInUser != "")
        {
            signedInWaiter = new SignedInWaiter(
                waiterCollection.waiters[ind].username,
                waiterCollection.waiters[ind].password,
                waiterCollection.waiters[ind].firstName,
                waiterCollection.waiters[ind].lastName
                );

            SceneManager.LoadScene("TableScene");
        }
        else
        {
            UserLoginHelper.text = "Wrong user id or password.";
        }
    }

    public SignedInWaiter getUserData()
    {
        return signedInWaiter;
    }
}
