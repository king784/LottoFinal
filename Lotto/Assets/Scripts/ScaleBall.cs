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
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerp);
            lerp += Time.deltaTime;
            yield return null;
        }
    }
}
