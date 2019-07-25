using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject noPrizesCanvas;
    public GameObject bsCanvas;

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
}
