using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset JSON;
    [System.Serializable]
    public class MenuItem
    {
        public string item;
        public string price;
    }
    [System.Serializable]

    public class MenuList
    {
        public MenuItem[] menu;
    }



    public MenuList mymenuList = new MenuList();

    // Start is called before the first frame update
    void Start()
    {
        mymenuList = JsonUtility.FromJson<MenuList>(JSON.text);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
