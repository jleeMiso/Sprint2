using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

[Serializable]
public class FetchMenu : MonoBehaviour
{
    [SerializeField]
    public Text CategoryText;

    [SerializeField]
    public Text Item1;

    [SerializeField]
    public Text Item2;

    [SerializeField]
    public Text Item3;

    [SerializeField]
    public Text Item4;

    [SerializeField]
    public Text FoodDescText;

    [SerializeField]
    public Text FoodPriceText;

    [SerializeField]
    public Text FoodQuantity;

    [SerializeField]
    public Text PendingOrderSummaryText;

    private MenuCollection menuCollection;

    private List<Menu> menu;

    private List<Menu> menuByCategory;

    public int quantity = 1;

    public PendingOrderCollection pendingOrderCollection = new PendingOrderCollection();

    public int numOfPendingitem = 0;

    private OrdersCollection ordersCollection;

    //private List<string> pendingItemDescArray = new List<string>();
    //private List<string> pendingItemQtyArray = new List<string>();

    public void FetchMenuByCatgory(string category)
    {
        using (StreamReader stream = new StreamReader("Assets/Resources/Menu.json"))
        {
            string json = stream.ReadToEnd();

            menuCollection = JsonUtility.FromJson<MenuCollection>(json);

            menu = menuCollection.menus.ToList();
            menuByCategory = menuCollection.filterMenus(category);
        }

        CategoryText.text = category;
        int i = 0;
        menuByCategory.ForEach(item =>
        {
            if (item.category == category)
            {
                if (i == 0)
                {
                    Item1.text = item.item;
                }
                else if (i == 1)
                {
                    Item2.text = item.item;
                }
                else if (i == 2)
                {
                    Item3.text = item.item;
                }
                else
                {
                    Item4.text = item.item;
                }
            }

            i++;
        });
    }

    public void OnClose()
    {
        Item1.text = "";
        Item2.text = "";
        Item3.text = "";
        Item4.text = "";
    }

    public void fetchItemDetail(int index)
    {
        FoodDescText.text = menuByCategory[index].item;
        FoodPriceText.text = menuByCategory[index].price;
        FoodQuantity.text = quantity.ToString();
    }

    public void OnClickPlusQuantity()
    {
        quantity += 1;
        FoodQuantity.text = quantity.ToString();
    }

    public void OnClickMinusQuantity()
    {
        if (quantity > 0)
        {
            quantity -= 1;
            FoodQuantity.text = quantity.ToString();
        }
    }

    public void OnClickSave()
    {
        PendingOrder pendingOrder = new PendingOrder(FoodDescText.text.ToString(), FoodQuantity.text.ToString());
        if (pendingOrder.Item != null && pendingOrder.Quantity != null)
        {
            pendingOrderCollection.AddItem(pendingOrder.Item, pendingOrder.Quantity);
            quantity = 1;
            FoodQuantity.text = "1";
        }
    }

    public void OnCloseItemDetail()
    {
        quantity = 1;
        FoodQuantity.text = "1";
    }

    private void Update()
    {
        FoodQuantity.text = quantity.ToString();

        if (numOfPendingitem != pendingOrderCollection.ItemsCollection.Count)
        {
            string result = "";

            for (int i = 0; i < pendingOrderCollection.ItemsCollection.Count; i++)
            {
                result += pendingOrderCollection.ItemsCollection[i] + "    " + pendingOrderCollection.QuantityCollection[i] + "\n";
            }
            PendingOrderSummaryText.text = result;
        }
    }

    public void OnClickCompleteOrder()
    {
        string TableID = "T4";
        //string OrderID = "";
        string WaiterID = "";
        string[] OrderedItems = pendingOrderCollection.ItemsCollection.ToArray();
        string[] Quantity = pendingOrderCollection.QuantityCollection.ToArray();
        string Total = "";
        string Paid = "false";

        decimal totalPrice = 0.00M;

        for (int i = 0; i < OrderedItems.Length; i++)
        {
            for (int y = 0; y < menu.Count; y++)
            {
                if (OrderedItems[i].Equals(menu[y].item))
                {
                    totalPrice += decimal.Parse(menu[y].price) * int.Parse(Quantity[i]);
                }
            }
        }

        Total = totalPrice.ToString();

        //Order newOrder = new Order(TableID, OrderID, WaiterID, OrderedItems, Quantity, Total, Paid);

        using (StreamReader stream = new StreamReader("Assets/Orders.json"))
        {
            string json = stream.ReadToEnd();

            ordersCollection = JsonUtility.FromJson<OrdersCollection>(json);
        }


        int index = ordersCollection.count() + 1;

        List<Order> revisedOrder = ordersCollection.orders.ToList();

        revisedOrder.Add(new Order(TableID, index.ToString(), WaiterID, OrderedItems, Quantity, Total, Paid));

        ordersCollection.orders = revisedOrder.ToArray();

        File.WriteAllText("Assets/Orders.json", JsonUtility.ToJson(ordersCollection));

        PendingOrderSummaryText.text = "";
    }

    public void onClickPayment()
    {
        SceneManager.LoadScene("FinalPayment");
    }
}
