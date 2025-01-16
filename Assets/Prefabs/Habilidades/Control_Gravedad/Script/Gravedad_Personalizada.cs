using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravedad_Personalizada : MonoBehaviour
{
    public Transform t_objeto_receptor;
    public bool b_fuerza_y = true;
    public bool b_fuerza_z = true;

    public float f_fuerza_atraccion = 9.8f;


    public Vector3 Gravedad_Hacia_Objeto()
    {
        float f_direfencia_y = 0;
        float f_direfencia_z = 0;

        if (t_objeto_receptor == null)
            return Vector3.zero;
        if (b_fuerza_y)
            f_direfencia_y = transform.position.y - t_objeto_receptor.position.y;

        if (b_fuerza_z)
            f_direfencia_y = transform.position.z - t_objeto_receptor.position.z;

        return new Vector3(0, f_direfencia_y, f_direfencia_z).normalized * f_fuerza_atraccion * Time.deltaTime;

    }
}
