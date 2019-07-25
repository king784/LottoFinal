using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{

    Animator anim;
    public GameObject paneeli;
    RandomizePrize rp;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rp = FindObjectOfType<RandomizePrize>();
    }

    public void startGameButton(){
        if(!rp.ballsSpawned)
        {
            return;
        }
        FindObjectOfType<RandomizePrize>().CanTouch = true;
        anim.SetBool("startade", true);
        StartCoroutine(toTheGame());
    }

    IEnumerator toTheGame(){
        yield return new WaitForSeconds(0.5f);
        //anim.SetBool("startade", true);
        paneeli.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        FindObjectOfType<RandomizePrize>().Lottery();
    }
}
