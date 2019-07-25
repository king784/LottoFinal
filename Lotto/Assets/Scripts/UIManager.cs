using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject noPrizesCanvas;
    public GameObject bsCanvas;
    // Item canvas stuff
    public GameObject itemCanvas;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemNameDesc;

    public void ShowBSCanvas()
    {
        StartCoroutine(ShowBSCanvasCO());
    }

    IEnumerator ShowBSCanvasCO()
    {
        bsCanvas.SetActive(true);
        yield return null;
    }

    public void ShowNoPrizesCanvas()
    {
        StartCoroutine(ShowNoPrizesCanvasCO());
    }

    IEnumerator ShowNoPrizesCanvasCO()
    {
        noPrizesCanvas.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        noPrizesCanvas.SetActive(false);
    }

    public void ShowItemCanvas(Item winItem)
    {
        itemCanvas.SetActive(true);
        itemNameText.text = winItem.itemName;
        itemNameDesc.text = winItem.description;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
