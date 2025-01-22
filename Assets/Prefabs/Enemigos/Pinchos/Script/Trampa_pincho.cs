using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trampa_pincho : MonoBehaviour {

    //This script goes on the SpikeTrap prefab;

    public Animator spikeTrapAnim;
    private Control_Enemigo Control_Enemigo;

    void Awake()
    {


        //get the Animator component from the trap;
        spikeTrapAnim = GetComponent<Animator>();
        //start opening and closing the trap for demo purposes;
        StartCoroutine(OpenCloseTrap());
    }

    void Update()
    {

    }

    IEnumerator OpenCloseTrap()
    {
        //play open animation;
        spikeTrapAnim.SetTrigger("open");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //play close animation;
        spikeTrapAnim.SetTrigger("close");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //Do it again;
        StartCoroutine(OpenCloseTrap());

    }
}