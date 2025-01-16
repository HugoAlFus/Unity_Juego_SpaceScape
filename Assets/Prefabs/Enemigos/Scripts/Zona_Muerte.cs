using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona_Muerte : MonoBehaviour
{

    private Control control;

    private void Start()
    {
        control = FindAnyObjectByType<Control>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (control != null)
        {
            if (other.GetComponent<CharacterController>() != null)
                control.Reinicio();
        }

    }

}
