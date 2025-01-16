using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_habilidad : MonoBehaviour
{

    public Transform t_objetico_vertical_1;
    public Transform t_objetivo_vertical_2;
    public float f_velocidad_rotacion = 20f;
    public float f_velocidad_vertical = 10f;

    private Vector3 v3_objetivo;
    private float f_eje_y;

    void Update()
    {
        if(transform.parent.GetComponent<CharacterController>() == null)
        {
            Rotar_habilidad();
            Mover_habilidad();
        }
       
    }

    private void Mover_habilidad()
    {
      

        if (transform.position == t_objetico_vertical_1.position)
            v3_objetivo = t_objetivo_vertical_2.position;
        if (transform.position == t_objetivo_vertical_2.position)
            v3_objetivo = t_objetico_vertical_1.position;

        transform.position = Vector3.MoveTowards(transform.position, v3_objetivo,
            f_velocidad_vertical * Time.deltaTime);
    }

    private void Rotar_habilidad()
    {
        f_eje_y += Time.deltaTime * f_velocidad_rotacion;
        transform.rotation = Quaternion.Euler(0, f_eje_y, 0);
    }
}
