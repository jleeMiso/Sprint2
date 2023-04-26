using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RemoveOrder : MonoBehaviour
{
    public Button theButton;
    public GameObject PText;
    // Start is called before the first frame update
    void Start()
    {
        theButton = this.GetComponentInChildren<Button>();
        Button btn = theButton.GetComponent<Button>();
        btn.onClick.AddListener(Remove);
        PText = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    void Remove()
    {
        Destroy(PText);
        OrderUpdate();
    }
    void OrderUpdate()
    {

    }
}
