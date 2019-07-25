using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CallRemoveFromDB : MonoBehaviour
{
    public void RemoveFromDB()
    {
        string tempID = transform.parent.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        Debug.Log(tempID);
        Item tempItem = FindObjectOfType<ItemManager>().allItems.Find(newItem => newItem.itemId.ToString() == tempID);
        Debug.Log(tempItem.itemId.ToString() + " " + tempItem.itemName + " " + tempItem.description + " ");
        FindObjectOfType<ItemManager>().winItem = tempItem;
        FindObjectOfType<ItemManager>().DeleteFromDB();
        Destroy(transform.parent.gameObject);
    }
}
