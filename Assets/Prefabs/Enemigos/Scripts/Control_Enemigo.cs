using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Enemigo : MonoBehaviour
{
    private bool b_jugador_dentro = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            b_jugador_dentro = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            b_jugador_dentro = false;
    }
}
