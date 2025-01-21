using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Camara_Menu : MonoBehaviour
{
    public Transform t_a_seguir;
    public bool b_seguir = true;
    public bool b_mirar = true;

    Vector3 v3_punt_sense_jugador = Vector3.zero;

    public float f_lookat = 1000f;
    float f_tiempo_velocidad = 0.3f;
    float f_tiempo_lookat = 0.3f;

    Vector3 v3_velocidad_smoothdamp = Vector3.zero;
    Vector3 v3_lookat_smoothdamp = Vector3.zero;

    private void Start()
    {
        v3_punt_sense_jugador = transform.position;
    }

    public void Configurar_Camara(Vector3 v3_posicio_final,
        float f_tmps_vlctt, float f_tmps_lkt,
        float f_lkt)
    {
        b_seguir = true;
        f_lookat = f_lkt;
        f_tiempo_velocidad = f_tmps_vlctt;
        f_tiempo_lookat = f_tmps_lkt;
    }

    public void Configurar_Camara_Fija(Vector3 v3_posicio_final,
        float f_tmps_lkt,
        float f_lkt)
    {
        b_seguir = false;
        transform.position = v3_posicio_final;
        f_lookat = f_lkt;
        f_tiempo_lookat = f_tmps_lkt;
    }

    // Update is called once per frame
    void Update()
    {
        if (t_a_seguir == null && !b_seguir && !b_mirar)
        {
            transform.Rotate(Vector3.up, 20f * Time.deltaTime, Space.World);
            transform.position = Vector3.SmoothDamp(
               transform.position,
               v3_punt_sense_jugador,
               ref v3_velocidad_smoothdamp,
               1f);
            return;
        }


        if (b_seguir && t_a_seguir != null)
            transform.position = Vector3.SmoothDamp(
                transform.position,
                t_a_seguir.TransformPoint(Vector3.zero),
                ref v3_velocidad_smoothdamp,
                f_tiempo_velocidad);

        if (b_mirar && t_a_seguir != null)
            transform.LookAt(Vector3.SmoothDamp(
                transform.TransformPoint(Vector3.forward * f_lookat),
                t_a_seguir.TransformPoint(Vector3.forward * f_lookat),
                ref v3_lookat_smoothdamp,
                f_tiempo_lookat));
    }
}
