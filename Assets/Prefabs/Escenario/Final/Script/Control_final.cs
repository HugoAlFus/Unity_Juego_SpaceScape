using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_final : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindAnyObjectByType<Control>().Apagar_Luces_Intermitentes();
            FindAnyObjectByType<Control_Aplicacion>().Cargar_Escena(0);
        }
    }

}
