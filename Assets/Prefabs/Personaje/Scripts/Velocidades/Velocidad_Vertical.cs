using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidad_Vertical : MonoBehaviour, IVelocidad_Personaje
{
    public float f_impulso_salto = 5f;

    private Vector3 v3_g_vertical = Vector3.zero;
    CharacterController cc_personaje;

    public void Reinicio()
    {
        v3_g_vertical = Vector3.zero;
    }

    public Vector3 Velocidad(bool b_toca_piso, RaycastHit hit)
    {

        Fuerza_Gravedad(b_toca_piso);

        //Debug.Log("Velocidad fuerza gravedad: " + v3_g_vertical);

        Realizar_Salto(b_toca_piso);    

        return v3_g_vertical;
    }

    void Realizar_Salto(bool b_toca_piso)
    {
       

        if (b_toca_piso)
        {
            Vector3 v3_direccion_abajo = transform.TransformDirection(Vector3.down).normalized;
            if (Input.GetKey(KeyCode.Space))
            {

                
                v3_g_vertical = -v3_direccion_abajo * f_impulso_salto;
                GetComponentInChildren<IAnimacion>().Animar_Salto();
                Debug.Log(v3_g_vertical);

            }
            else
                v3_g_vertical = Vector3.zero;
        }
        

    }

    void Fuerza_Gravedad(bool b_toca_piso)
    {
        if ((cc_personaje.collisionFlags & CollisionFlags.Above) != 0)
        {
            v3_g_vertical = Vector3.down * 1.25f;
        }

        if (b_toca_piso && v3_g_vertical.y <= 0)
            v3_g_vertical = Vector3.zero;



        v3_g_vertical += Physics.gravity * Time.deltaTime;

    }


    void Start()
    {
        cc_personaje = GetComponent<CharacterController>();
    }
}