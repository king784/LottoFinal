using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRandomForce : MonoBehaviour
{
    float minForce = 20.0f;
    float maxForce = 40.0f;
    bool shaking = true;
    void Start()
    {
        //StartCoroutine(CustomUpdate());
    }
    IEnumerator CustomUpdate()
    {
        while(shaking)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(
                Random.Range(minForce, maxForce),
                Random.Range(minForce, maxForce),
                Random.Range(minForce, maxForce)
            ), ForceMode.Impulse);
            yield return new WaitForSeconds(0.5f);
        }    
    }
}
