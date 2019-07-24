using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBall : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(StartScale());
    }

    IEnumerator StartScale()
    {
        float lerp = 0.0f;
        while(lerp <= 1.0f)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Easing.EaseOutBounce(lerp));
            lerp += Time.deltaTime * 0.2f;
            yield return null;
        }
    }
}
