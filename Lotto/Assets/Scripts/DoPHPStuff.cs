using System.Collections;
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
    public GameObject bsCanvas;
    public GameObject deletingCanvas;
    bool prizesLoaded = false;

    //raffle settings
    public TMP_InputField totalTickets;
    public TMP_InputField winningChance;
    public TMP_InputField raffleName;

    // void Start()
    // {
    //     if (!prizesLoaded)
    //     {
    //         GetAllItems();
    //     }
    // }

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
                FindObjectOfType<UIManager>().ShowBSCanvas();
            }
            else if (www.isHttpError)
            {
                FindObjectOfType<UIManager>().ShowBSCanvas();
            }
            else
            {
                // Yay
            }
        }
    }

    public void RemovePHP()
    {
        StartCoroutine(RemovePHPCo());
    }

    IEnumerator RemovePHPCo()
    {
        deletingCanvas.SetActive(true);
        WWWForm form = new WWWForm();
        form.AddField("itemName", itemName.text);
        form.AddField("itemId", itemId.text);

        using (UnityWebRequest www = UnityWebRequest.Post("https://arvonta.000webhostapp.com/Remove.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                FindObjectOfType<UIManager>().ShowBSCanvas();
            }
            else if (www.isHttpError)
            {
                FindObjectOfType<UIManager>().ShowBSCanvas();
            }
            else
            {
                // Done
            }
        }
        deletingCanvas.SetActive(false);
    }

    public void RemovePHPWithParameters(string newId, string newName)
    {
        StartCoroutine(RemovePHPWithParametersCo(newId, newName));
    }

    public IEnumerator RemovePHPWithParametersCo(string newId, string newName)
    {
        deletingCanvas.SetActive(true);
        WWWForm form = new WWWForm();
        form.AddField("itemName", newName);
        form.AddField("itemId", newId);

        using (UnityWebRequest www = UnityWebRequest.Post("https://arvonta.000webhostapp.com/Remove.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                FindObjectOfType<UIManager>().ShowBSCanvas();
            }
            else if (www.isHttpError)
            {
                FindObjectOfType<UIManager>().ShowBSCanvas();
            }
            else
            {
                // works
            }
        }
        deletingCanvas.SetActive(false);
    }

    public void GetAllItems()
    {
        StartCoroutine(GetAllPrizesCo());
    }

    public IEnumerator GetAllPrizesCo()
    {
        ItemManager itemManager = FindObjectOfType<ItemManager>();
        using (UnityWebRequest www = UnityWebRequest.Get("https://arvonta.000webhostapp.com/GetItems.php"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                FindObjectOfType<UIManager>().ShowBSCanvas();
            }
            else if (www.isHttpError)
            {
                FindObjectOfType<UIManager>().ShowBSCanvas();
            }
            else
            {
                string itemsDataFromDB = www.downloadHandler.text;
                //Debug.Log(itemsDataFromDB);

                string[] allItems = itemsDataFromDB.Split(';');

                Debug.Log(allItems.Length);

                if(allItems.Length != 1)
                {
                    foreach (string item in allItems)
                    {
                        //Debug.Log(item);
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
                prizesLoaded = true;
            }
        }
    }
    public IEnumerator GetRaffleSettings()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://arvonta.000webhostapp.com/GetRaffleSettings.php"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                FindObjectOfType<UIManager>().ShowBSCanvas();
            }
            else if (www.isHttpError)
            {
                FindObjectOfType<UIManager>().ShowBSCanvas();
            }
            else
            {
                string settingsDataFromDB = www.downloadHandler.text;
                //Debug.Log(itemsDataFromDB);

                string[] allItems = settingsDataFromDB.Split(';');

                if(allItems.Length != 1)
                {
                    foreach (string item in allItems)
                    {
                        //Debug.Log(item);
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
                            FindObjectOfType<RaffleSettings>().setSettings(tempParameters[0], tempParameters[1], tempParameters[2]);

                        }

                    }
                }
                prizesLoaded = true;
            }
        }
    }
    public void SaveRaffleSettingsToDB()
    {
        StartCoroutine(AddSettingsToDB());
    }

    IEnumerator AddSettingsToDB()
    {
        WWWForm form = new WWWForm();
        form.AddField("raffleName", raffleName.text);
        form.AddField("totalTickets", totalTickets.text);
        form.AddField("winningChance", winningChance.text);

        using (UnityWebRequest www = UnityWebRequest.Post("https://arvonta.000webhostapp.com/RaffleSettings.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                FindObjectOfType<UIManager>().ShowBSCanvas();
            }
            else if (www.isHttpError)
            {
                FindObjectOfType<UIManager>().ShowBSCanvas();
            }
            else
            {
                // Yay
            }
        }
    }
}
