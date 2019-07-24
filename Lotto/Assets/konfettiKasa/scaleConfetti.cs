using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleConfetti : MonoBehaviour
{
    public float alphaSpeed;
    public GameObject[] konfettiKasa = new GameObject[6];

    int next = 0;
    bool doIt = true;
    void Update()
    {   
        if(next < 6){
            konfettiKasa[next].GetComponent<SpriteRenderer>().color += new Color(0,0,0,alphaSpeed);      
            if(doIt){
                StartCoroutine(delay());
                nextSprite();
            }

        }
    }

    void nextSprite(){
        Debug.Log(next + " " + konfettiKasa[next].gameObject.name);
        Debug.Log(next);
        next++;

    }

    IEnumerator delay(){
        doIt = false;
        yield return new WaitForSeconds(2);
        //nextSprite();
        doIt = true;
        Debug.Log("pöö");
    }
}
