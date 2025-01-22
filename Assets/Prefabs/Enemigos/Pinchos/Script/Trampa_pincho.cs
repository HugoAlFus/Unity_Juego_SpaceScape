using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trampa_pincho : MonoBehaviour
{

    //This script goes on the SpikeTrap prefab;

    public Animator spikeTrapAnim;

    void Awake()
    {
        spikeTrapAnim = GetComponent<Animator>();

    }

    public IEnumerator OpenCloseTrap()
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

    }

    public void Cerrar_Trampa()
    {
        spikeTrapAnim.SetTrigger("close");
    }
}