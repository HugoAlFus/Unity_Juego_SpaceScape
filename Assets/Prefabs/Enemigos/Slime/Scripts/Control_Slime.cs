using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Slime : MonoBehaviour
{

    private Movimiento_puntos movimiento_Puntos;

    private void Start()
    {
        movimiento_Puntos = GetComponent<Movimiento_puntos>();

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Dentro rango slime");

        if (other.tag == "Player")
            movimiento_Puntos.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            movimiento_Puntos.enabled = false;
    }
}
