using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Cañon : MonoBehaviour
{

    private bool b_esta_dentro = false;

    public bool B_esta_dentro { get => b_esta_dentro; set => b_esta_dentro = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            B_esta_dentro = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            B_esta_dentro = false;
    }
}
