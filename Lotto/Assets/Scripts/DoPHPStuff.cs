﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class DoPHPStuff : MonoBehaviour
{
    public TMP_InputField itemName;
    public TMP_InputField itemDesc;
    public TMP_InputField quantity;

    public TMP_InputField itemId;

    public void AddPHP()
    {
        StartCoroutine(AddPHPCo());
    }

    IEnumerator AddPHPCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("itemName", itemName.text);
        form.AddField("itemDesc", itemDesc.text);
        form.AddField("quantity", quantity.text);

        using (UnityWebRequest www = UnityWebRequest.Post("https://arvonta.000webhostapp.com/Add.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log("Network error");
            }
            else if (www.isHttpError)
            {
                Debug.Log("HTTP error!!");
            }
            else
            {
                Debug.Log("Yay!!");
            }
        }
    }

    public void RemovePHP()
    {
        StartCoroutine(RemovePHPCo());
    }

    IEnumerator RemovePHPCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("itemName", itemName.text);
        form.AddField("itemId", itemId.text);

        using (UnityWebRequest www = UnityWebRequest.Post("https://arvonta.000webhostapp.com/Remove.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log("Network error");
            }
            else if (www.isHttpError)
            {
                Debug.Log("HTTP error!!");
            }
            else
            {
                Debug.Log("Yay!!");
            }
        }
    }

    public void GetAllItems()
    {
        StartCoroutine(GetAllPrizesCo());
    }

    IEnumerator GetAllPrizesCo()
    {
        ItemManager itemManager = FindObjectOfType<ItemManager>();
        using (UnityWebRequest www = UnityWebRequest.Get("https://arvonta.000webhostapp.com/GetItems.php"))
        {
            yield return www.SendWebRequest();

            string itemsDataFromDB = www.downloadHandler.text;
            //Debug.Log(itemsDataFromDB);

            string[] allItems = itemsDataFromDB.Split(';');

            foreach (string item in allItems)
            {
                Debug.Log(item);
                if (item.Length > 1)
                {
                    string[] itemParameters = item.Split('|');

                    string[] tempParameters = new string[3];

                    for (int i = 0; i < itemParameters.Length; i++)
                    {
                        string[] result = itemParameters[i].Split(':');
                        tempParameters[i] = result[1];
                    }
                    //Debug.Log("\nTemp variables:\n" + tempParameters[0] + ", " + tempParameters[1] + ", " + tempParameters[2]);
                    itemManager.addItemToList(tempParameters[0], tempParameters[1], tempParameters[2]);

                }

            }
        }
    }
}
