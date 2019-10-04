using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRandomizer : MonoBehaviour
{
    [SerializeField]
    float minForce = 15.0f; //3
    [SerializeField]
    float maxForce = 20.0f; //15

    public Vector3 randomizedVec;

    void Start()
    {
        GetRandomNumber();
        gameObject.GetComponent<Rigidbody>().AddForce(randomizedVec, ForceMode.Impulse);
    }

    void GetRandomNumber()
    {
        randomizedVec = new Vector3(
            Random.Range(minForce, maxForce),
            Random.Range(minForce, maxForce),
            Random.Range(minForce, maxForce)
        );
    }
}
