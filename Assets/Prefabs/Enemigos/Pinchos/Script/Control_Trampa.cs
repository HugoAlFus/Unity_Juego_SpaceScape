using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Trampa : MonoBehaviour
{

    private Trampa_pincho trampa_Pincho;
    private IEnumerator coroutine_actual;
    float f_contador = 0f;

    private void Start()
    {
        trampa_Pincho = GetComponent<Trampa_pincho>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);

        if (other.tag == "Player")
        {
            coroutine_actual = trampa_Pincho.OpenCloseTrap();
            StartCoroutine(coroutine_actual);
        }
        


    }

    private void OnTriggerStay(Collider other)
    {


        if (other.tag == "Player")
        {
            f_contador += Time.deltaTime;

            if (f_contador >= 4)
            {
                f_contador = 0;
                coroutine_actual = trampa_Pincho.OpenCloseTrap();
                StartCoroutine(coroutine_actual);


            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopCoroutine(coroutine_actual);
            trampa_Pincho.Cerrar_Trampa();
        }

    }
}
