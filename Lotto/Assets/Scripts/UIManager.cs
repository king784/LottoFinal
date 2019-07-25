using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
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
}
