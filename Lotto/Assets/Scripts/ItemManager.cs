using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<Item> allItems = new List<Item>();

    public void addItemToList(string id, string name, string description)
    {

        int idAsInt;
        bool conversionSuccess = int.TryParse(id, out idAsInt);
        //Debug.Log(string.Format($"Adding item to all items, id conversion: {conversionSuccess}"));
        if (conversionSuccess)
        {
            allItems.Add(new Item(idAsInt, name, description));
        }

    }

}
