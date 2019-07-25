using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{

    Animator anim;
    public GameObject paneeli;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void startGameButton(){
        FindObjectOfType<RandomizePrize>().CanTouch = true;
        anim.SetBool("startade", true);
        StartCoroutine(toTheGame());
    }

    IEnumerator toTheGame(){
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("startade", true);
        paneeli.SetActive(false);
    }
}
