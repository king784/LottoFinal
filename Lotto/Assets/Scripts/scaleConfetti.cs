using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleConfetti : MonoBehaviour
{
    public float alphaSpeed;
    public GameObject[] konfettiKasa;
    Color nextColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    bool hasFanfared = false;

    int next = 0;
    bool doIt = true;

    public IEnumerator spawnConfetties(){    
        if(!hasFanfared)
        {
            GameObject.Find("Trumpets").GetComponent<trumpetsScript>().fanfare();
            hasFanfared = true;
        }

        yield return new WaitForSeconds(7.5f);
        
        if(next < konfettiKasa.Length){
            nextColor += new Color(0,0,0,alphaSpeed);
            konfettiKasa[next].GetComponent<SpriteRenderer>().color = nextColor;
            Debug.Log(konfettiKasa[next] + " " + nextColor.a); 

            if(doIt && nextColor.a >= 1.0f){
                StartCoroutine(delay());
                nextSprite();
            }

        }
    }

    void nextSprite(){
        nextColor = new Color(1,1,1,0);
        //Debug.Log(next + " " + konfettiKasa[next].gameObject.name);
        //Debug.Log(next);
        next++;

    }

    IEnumerator delay(){
        doIt = false;
        yield return new WaitForSeconds(0.1f);
        //nextSprite();
        doIt = true;
        Debug.Log("pöö");
    }
}
