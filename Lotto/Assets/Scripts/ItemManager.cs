using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    public List<Item> allItems = new List<Item>();
    public Item winItem;

    public void ClearList()
    {
        allItems.Clear();
    }

    public void SortListAlphabetical()
    {
        allItems.Sort((x, y) => string.Compare(x.itemName, y.itemName));
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
        if(allItems.Count <= 0)
        {
            Item tempItem = new Item(0,"","");
            FindObjectOfType<UIManager>().ShowNoPrizesCanvas();
            return tempItem;
        }
        else
        {
            int randInt = Random.Range(0, allItems.Count);
            winItem = allItems[randInt];
            return winItem;
        }
    }

    public void DeleteFromDB()
    {
        StartCoroutine(DeleteFromDBCO());
    }

    IEnumerator DeleteFromDBCO()
    {
        allItems.Remove(winItem);
        // yield this
        FindObjectOfType<DoPHPStuff>().RemovePHPWithParameters(winItem.itemId.ToString(), winItem.itemName);
        yield return null;
    }

    public void DeleteFromDBInRaffle()
    {
        StartCoroutine(DeleteFromDBInRaffleCo());
    }

    public IEnumerator DeleteFromDBInRaffleCo()
    {
        allItems.Remove(winItem);
        yield return StartCoroutine(FindObjectOfType<DoPHPStuff>().RemovePHPWithParametersCo(winItem.itemId.ToString(), winItem.itemName));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
