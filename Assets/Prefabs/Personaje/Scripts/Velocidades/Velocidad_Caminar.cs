using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidad_Caminar : MonoBehaviour, IVelocidad_Personaje
{
    public KeyCode KC_derecha;
    public KeyCode KC_izquierda;

    public float f_velocidad = 5f;

    Vector3 v3_g_caminar = Vector3.zero;



    public void Reinicio()
    {
        v3_g_caminar = Vector3.zero;
    }

    public Vector3 Velocidad(bool b_toca_piso, RaycastHit hit)
    {
        if (b_toca_piso)
        {
            Vector3 v3_l_caminar = Vector3.zero;

            if (Input.GetKey(KC_derecha))
                v3_l_caminar += Vector3.forward;
            if (Input.GetKey(KC_izquierda))
                v3_l_caminar += -Vector3.forward;

            GetComponentInChildren<IAnimacion>().Animar_Por_Velocidad(v3_l_caminar);

            v3_g_caminar = Vector3.ProjectOnPlane(
               transform.TransformVector(v3_l_caminar),
               hit.normal).normalized * f_velocidad;
        }

        
        return v3_g_caminar;
    }

}
