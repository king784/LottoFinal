using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateChildPanels : MonoBehaviour
{
    ItemManager itemManager;
    public GameObject childPanel;
    public GameObject itemParent;

    void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
    }

    public void CreatePanels()
    {
        for(int i = 0; i < itemManager.allItems.Count; i++)
        {
            GameObject newPanel = GameObject.Instantiate(childPanel, itemParent.transform);
            newPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemManager.allItems[i].itemId.ToString();
            newPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemManager.allItems[i].itemName;
        }
    }
}
