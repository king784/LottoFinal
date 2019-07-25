using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RandomizePrize : MonoBehaviour
{
    public Transform ballSpawnPointT;
    public PhysicMaterial bouncyMat;
    public int emptyTicket;
    public int victoryTicket;
    public float lessBalls;
    public float winPercent;
    public int numOfBalls;
    List<GameObject> winBalls = new List<GameObject>();
    List<GameObject> loseBalls = new List<GameObject>();
    Camera mainCam;
    Transform camStartT;
    public Transform camEndT;
    Transform ballStartT;
    public Transform ballEndT;

    [SerializeField]
    ParticleSystem winPar;
    [SerializeField]
    ParticleSystem losePar;
    bool win = false;
    bool hasLottod = false;
    public LightColorScript lightColorScript;
    public Material ballMat;

    float minForce = 15.0f; //3
    float maxForce = 30.0f; //15
    public Item winItem;
    bool canTouch = false;
    bool ballsSpawned = false;
    public GameObject itemCanvas;
    public bool CanTouch
    {
        get
        {
            return canTouch;
        }
        set
        {
            canTouch = value;
        }
    }


    void Start()
    {
        mainCam = Camera.main;
        camStartT = mainCam.transform;
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && !hasLottod && canTouch && ballsSpawned)
        {
            Lottery();
        }
        if(Input.GetKeyDown(KeyCode.R) || Input.touchCount >= 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void SetRandomPrizeSettings(float newWinPercent, int newNumOfBalls)
    {
        winPercent = newWinPercent;
        numOfBalls = newNumOfBalls;
        SpawnBalls();
    }
    
    [ContextMenu("Lottoo")]
    public void Lottery()
    {
        hasLottod = true;
        float winfloat = Random.Range(0.0f, 100f);
        if(winfloat < winPercent)
        {
            win = true;
            winItem = FindObjectOfType<ItemManager>().RandomizeItem();
            if(winItem.itemName == "")
            {
                return;
            }
            StartCoroutine(ShowItemCanvasCooldown());
        }
        else
        {
            win = false;
        }
 
        StartCoroutine(MoveCameraToWin());
        StartCoroutine(MoveBallToWin());
    }

    IEnumerator ShowItemCanvasCooldown()
    {
        yield return new WaitForSeconds(5.0f);
        itemCanvas.SetActive(true);
        itemCanvas.transform.Find("ItemName").transform.GetComponent<TextMeshProUGUI>().text = winItem.itemName;
        itemCanvas.transform.Find("ItemDescription").transform.GetComponent<TextMeshProUGUI>().text = winItem.description;
    }

    IEnumerator MoveCameraToWin()
    {
        float lerp = 0;
        while(lerp <= 1)
        {
            mainCam.transform.position = Vector3.Lerp(camStartT.position, camEndT.position, lerp);
            lerp += Time.deltaTime * 0.1f;
            ///
            if(win)
                StartCoroutine(GameObject.Find("ConfettiesStacking").GetComponent<scaleConfetti>().spawnConfetties());
            ///
            yield return null;
        }
    }

    IEnumerator MoveBallToWin()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject tempBall;
        if(win)
        {
            int victoryBall = Random.Range(0, winBalls.Count);
            tempBall = winBalls[victoryBall];
            winBalls[victoryBall].GetComponent<Rigidbody>().velocity = Vector3.zero;
            winBalls[victoryBall].GetComponent<SphereCollider>().enabled = false;
            ballStartT = winBalls[victoryBall].transform;
            StartCoroutine(ParticleCooldown(winPar, 1f));
            lightColorScript.StartLightCO(true);
        }
        else
        {
            int victoryBall = Random.Range(0, loseBalls.Count);
            tempBall = loseBalls[victoryBall];
            loseBalls[victoryBall].GetComponent<Rigidbody>().velocity = Vector3.zero;
            loseBalls[victoryBall].GetComponent<SphereCollider>().enabled = false;
            ballStartT = loseBalls[victoryBall].transform;
            StartCoroutine(ParticleCooldown(losePar, 0.8f));
            lightColorScript.StartLightCO(false);
        }

        float lerp = 0;
        while(lerp <= 1f)
        {
            tempBall.transform.position = Vector3.Lerp(ballStartT.position, ballEndT.position, Easing.EaseOutBounce(lerp));
            lerp += Time.deltaTime * 0.1f;               
            yield return null;
        }   
    }

    IEnumerator ParticleCooldown(ParticleSystem ps, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ps.Play();
    }

    public void SpawnBalls()
    {
        float awesomeNum = (float)numOfBalls*(winPercent*0.01f);
        for(int i = 0; i < Mathf.FloorToInt(awesomeNum); i++)
        {
            SpawnBall(true);
        }

        for(int i = 0; i < Mathf.FloorToInt(numOfBalls-awesomeNum); i++)
        {
            SpawnBall(false);
        }
        ballsSpawned = true;
    }

    void SpawnBall(bool win)
    {
        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.position = ballSpawnPointT.position;
        ball.AddComponent<Rigidbody>();
        ball.AddComponent<ScaleBall>();
        ball.GetComponent<SphereCollider>().material = bouncyMat;
        ball.GetComponent<Rigidbody>().AddForce(new Vector3(
            Random.Range(minForce, maxForce),
            Random.Range(minForce, maxForce),
            Random.Range(minForce, maxForce)
        ), ForceMode.Impulse);
        ball.gameObject.layer = 9;
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.GetComponent<Rigidbody>().mass = 0.0f;
        ball.GetComponent<Renderer>().material = ballMat;
        if(win)
        {
            winBalls.Add(ball);
            ball.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            loseBalls.Add(ball);
            ball.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
