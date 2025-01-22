using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento_puntos : MonoBehaviour
{
    public Transform t_punto_inicial;
    public Transform t_punto_final;
    public Transform t_a_mover;
    public float f_velocidad = 5f;

    private Vector3 v3_objetivo;
    private Control_animacion control_Animacion;
    void Start()
    {
        v3_objetivo = t_punto_inicial.position;
        control_Animacion = t_a_mover.GetComponent<Control_animacion>();
    }
    void Update()
    {
        if (v3_objetivo != null)
        {
            if (t_a_mover.position == t_punto_inicial.transform.position)
            {
                v3_objetivo = t_punto_final.transform.position;

                //Debug.Log(Quaternion.identity);

               if (t_a_mover.rotation.y != Quaternion.identity.y)
                    t_a_mover.Rotate(new Vector3(0, 180, 0));
            }



            if (t_a_mover.position == t_punto_final.transform.position)
            {
                v3_objetivo = t_punto_inicial.transform.position;
                t_a_mover.Rotate(new Vector3(0, 180, 0));
            }


            t_a_mover.position = Vector3.MoveTowards(t_a_mover.position, v3_objetivo, f_velocidad * Time.deltaTime);
            if (control_Animacion != null)
                control_Animacion.Animar_Por_Velocidad(t_a_mover.position);
        }

    }
}
