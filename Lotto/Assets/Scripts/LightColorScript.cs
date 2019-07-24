using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColorScript : MonoBehaviour
{
    bool doingLightShow = false;
    Light lightComponent;

    void Start()
    {
        lightComponent = GetComponent<Light>();
    }

    public void StartLightCO(bool win)
    {
        if(win)
        {
            doingLightShow = true;
            StartCoroutine(LightShow());
        }
        else
        {
            lightComponent.color = Color.red;
        }
    }

    IEnumerator LightShow()
    {
        Color startCol;
        Color endCol;
        while(doingLightShow)
        {
            float lerp = 0;
            startCol = lightComponent.color;
            endCol = GetRandomCol();
            while(lerp <= 1)
            {
                lightComponent.color = Color.Lerp(startCol, endCol, lerp);
                lerp += Time.deltaTime;
                yield return null;
            }
        }
    }

    Color GetRandomCol()
    {
        bool goodCol = false;
        Color randCol = new Color();
        while(!goodCol)
        {
            randCol = new Color(
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f)
            );
            if(randCol.r >= 0.8f || randCol.g >= 0.8f || randCol.b >= 0.8f)
            {
                goodCol = true;
            }
        }
        return randCol;
    }
}
