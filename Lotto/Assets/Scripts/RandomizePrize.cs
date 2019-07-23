using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePrize : MonoBehaviour
{
    public Transform ballSpawnPointT;
    public PhysicMaterial bouncyMat;
    public int emptyTicket;
    public int victoryTicket;
    public float lessBalls;
    List<GameObject> balls = new List<GameObject>();
    Camera mainCam;
    Transform camStartT;
    public Transform camEndT;
    Transform ballStartT;
    public Transform ballEndT;

    void Start()
    {
        mainCam = Camera.main;
        camStartT = mainCam.transform;
        SpawnBalls();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Lottery();
        }
    }
    
    [ContextMenu("Lottoo")]
    public void Lottery()
    {
        int winInt = Random.Range(0, (emptyTicket + victoryTicket));
        Debug.Log(winInt);
        if(winInt < emptyTicket)
        {
            Debug.Log("Hävisit");
        }
        else
        {
            Debug.Log("Voitit");
        }
        StartCoroutine(MoveCameraToWin());
        StartCoroutine(MoveBallToWin(Mathf.FloorToInt(winInt*lessBalls)));
    }

    IEnumerator MoveCameraToWin()
    {
        float lerp = 0;
        while(lerp <= 1)
        {
            mainCam.transform.position = Vector3.Lerp(camStartT.position, camEndT.position, lerp);
            lerp += Time.deltaTime * 0.1f;
            yield return null;
        }
    }

    IEnumerator MoveBallToWin(int victoryBall)
    {
        yield return new WaitForSeconds(0.5f);

        balls[victoryBall].GetComponent<Rigidbody>().velocity = Vector3.zero;
        balls[victoryBall].GetComponent<SphereCollider>().enabled = false;
        ballStartT = balls[victoryBall].transform;

        float lerp = 0;
        while(lerp <= 1)
        {
            balls[victoryBall].transform.position = Vector3.Lerp(ballStartT.position, ballEndT.position, lerp);
            lerp += Time.deltaTime * 0.1f;
            yield return null;
        }
    }

    public void SpawnBalls()
    {
        for(int i = 0; i < Mathf.FloorToInt(emptyTicket * lessBalls); i++)
        {
            GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            balls.Add(ball);
            ball.transform.position = ballSpawnPointT.position;
            ball.AddComponent<Rigidbody>();
            ball.GetComponent<SphereCollider>().material = bouncyMat;
            ball.AddComponent<AddRandomForce>();
            ball.GetComponent<Rigidbody>().useGravity = false;
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(
                Random.Range(1.0f, 3.0f),
                Random.Range(1.0f, 3.0f),
                Random.Range(1.0f, 3.0f)
            ), ForceMode.Impulse);
            ball.GetComponent<Rigidbody>().mass = 0.0f;
            ball.GetComponent<Renderer>().material.color = Color.red;
        }

        for(int i = 0; i < Mathf.FloorToInt(victoryTicket * lessBalls); i++)
        {
            GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            balls.Add(ball);
            ball.transform.position = ballSpawnPointT.position;
            ball.AddComponent<Rigidbody>();
            ball.GetComponent<SphereCollider>().material = bouncyMat;
            ball.AddComponent<AddRandomForce>();
            ball.GetComponent<Rigidbody>().useGravity = false;
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(
                Random.Range(1.0f, 3.0f),
                Random.Range(1.0f, 3.0f),
                Random.Range(1.0f, 3.0f)
            ), ForceMode.Impulse);
            ball.GetComponent<Rigidbody>().mass = 0.0f;
            ball.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
