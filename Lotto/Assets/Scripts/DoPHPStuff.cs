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

        using(UnityWebRequest www = UnityWebRequest.Post("https://arvonta.000webhostapp.com/Add.php", form))
        {
            yield return www.SendWebRequest();

            if(www.isNetworkError)
            {
                Debug.Log("Network error");
            }
            else if(www.isHttpError)
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
        form.AddField("itemDesc", itemDesc.text);
        form.AddField("quantity", quantity.text);

        using(UnityWebRequest www = UnityWebRequest.Post("https://arvonta.000webhostapp.com/Remove.php", form))
        {
            yield return www.SendWebRequest();

            if(www.isNetworkError)
            {
                Debug.Log("Network error");
            }
            else if(www.isHttpError)
            {
                Debug.Log("HTTP error!!");
            }
            else
            {
                Debug.Log("Yay!!");
            }
        }
    }
}
