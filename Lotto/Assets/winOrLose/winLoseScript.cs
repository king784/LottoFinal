using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winLoseScript : MonoBehaviour
{

    public Material winLoseMat;
    public GameObject ball;

    public Text destiny;
    public GameObject panel;

    public ParticleSystem winFanfare;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            raffle();
        }
    }

    void raffle(){
        int rnd = Random.RandomRange(1, 100);
        if(rnd > 50){
            Debug.Log("VOITIT " + rnd);
            destiny.text = "VOITTO!";
            winLoseMat.color = new Color(0, 255, 0);
            winFanfare.Play();
        }
        else{
            Debug.Log("Hävisit " + rnd);
            destiny.text = "Hävisit :(";
            winLoseMat.color = new Color(255, 0, 0);

        }
        ball.GetComponent<Renderer>().material = winLoseMat;
        Invoke("showPanel", 2);
    }

    void showPanel(){
        panel.SetActive(true);
    }
}
