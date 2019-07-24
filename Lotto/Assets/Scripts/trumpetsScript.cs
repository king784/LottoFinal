using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trumpetsScript : MonoBehaviour
{
    Animator anim;
    public Transform matto;
    public ParticleSystem[] torviPS;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void fanfare(){
        //this.gameObject.SetActive(true);
        StartCoroutine(fanfareCO());
        matto.position += Vector3.up * 0.1f;
    }

    IEnumerator fanfareCO()
    {
        yield return new WaitForSeconds(0.8f);
        anim.SetBool("Honkhonk", true);
        yield return new WaitForSeconds(0.5f);
        torviPS[0].Play();
        yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));
        torviPS[1].Play();
    }
}
