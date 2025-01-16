using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movimiento_Camara : MonoBehaviour
{

    public Transform t_pos_cam;
    public Transform t_pos_cam_2;
    public float f_retraso_cam = 0.3f;

    private Vector3 v3_vel_smoothDamp = Vector3.zero;
    void LateUpdate()
    {

        if (!FindAnyObjectByType<Control_Gravedad>().B_invertir_gravedad)
        {
            transform.position = Mover_Camara(t_pos_cam);
        }
        else
        {
            transform.position = Mover_Camara(t_pos_cam_2);
        }

        //Debug.Log("Pos cam: " + transform.position);

    }

    Vector3 Mover_Camara(Transform t_cam_seguir)
    {
        Vector3 v3_pos_actual = transform.position;

        float f_smooth_z = Mathf.SmoothDamp(v3_pos_actual.z, t_cam_seguir.position.z, ref v3_vel_smoothDamp.z, f_retraso_cam);

        return new Vector3(v3_pos_actual.x, v3_pos_actual.y, f_smooth_z);

    }
}
