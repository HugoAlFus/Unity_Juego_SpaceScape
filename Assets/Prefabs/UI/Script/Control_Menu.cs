using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Menu : MonoBehaviour
{
    public Movimiento_Camara_Menu movimiento_Camara_Menu;

    public void Mover_a_menu(Transform t_a_seguir)
    {

        movimiento_Camara_Menu.t_a_seguir = t_a_seguir;

    }
}
