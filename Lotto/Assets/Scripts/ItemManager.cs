using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<Item> allItems = new List<Item>();

    static ItemManager instance = null;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    // Randomizes an item and removes it from local item list and database
    public Item RandomizeItem()
    {
        int randInt = Random.Range(0, allItems.Count);
        Item tempItem = allItems[randInt];
        allItems.RemoveAt(randInt);
        FindObjectOfType<DoPHPStuff>().RemovePHPWithParameters(tempItem.itemId.ToString(), tempItem.itemName);
        return tempItem;
    }
}
