using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MenuCollection
{
    public Menu[] menus;

    public List<Menu> filterMenus(string category)
    {
        List<Menu> menuByCategory = new List<Menu>();
        foreach (Menu menu in menus)
        {
            if (menu.category.Equals(category))
            {
                menuByCategory.Add(menu);
            }
        }
        return menuByCategory;
    }
}
