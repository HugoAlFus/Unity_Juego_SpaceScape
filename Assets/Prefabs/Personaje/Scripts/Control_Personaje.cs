using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Personaje : MonoBehaviour, IReinicio
{
    public float f_velocidad_rotacion = 30f;
    public float f_limite_vertical = -30f;

    private bool b_toca_piso = false;
    private bool b_resetear = false;
    private CharacterController cc_personaje;
    private Vector3 v3_pos_inicial = Vector3.zero;
    private Quaternion q_rot_inicial = Quaternion.identity;
    private RaycastHit rch_piso;

    private IVelocidad_Personaje[] velocidades;

    private void Start()
    {
        cc_personaje = GetComponent<CharacterController>();
        velocidades = GetComponents<IVelocidad_Personaje>();

        v3_pos_inicial = transform.position;
        q_rot_inicial = transform.rotation;

        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        Vector3 v3_direccion_abajo = transform.TransformDirection(Vector3.down).normalized;

        b_toca_piso = Physics.Raycast(transform.position, v3_direccion_abajo, out rch_piso,
       cc_personaje.height + 0.39f);
        //Debug.Log("Toca piso: " + b_toca_piso);
        Debug.DrawRay(transform.position, v3_direccion_abajo * (cc_personaje.height + 0.39f), Color.yellow);

        Vector3 v3_g_velocidad_total = CalcularVelocidadTotal();

        if (!b_resetear)
            cc_personaje.Move(v3_g_velocidad_total * Time.deltaTime);

        Reaparicion();
    }

    private Vector3 CalcularVelocidadTotal()
    {
        Vector3 velocidadTotal = Vector3.zero;

        foreach (IVelocidad_Personaje velocidad_Personaje in velocidades)
        {
            velocidadTotal += velocidad_Personaje.Velocidad(b_toca_piso, rch_piso);
        }

        return velocidadTotal;
    }


    private void Resetear()
    {
        foreach (IVelocidad_Personaje velocidad_Personaje in velocidades)
        {
            velocidad_Personaje.Reinicio();
        }

        transform.position = v3_pos_inicial;
        transform.rotation = q_rot_inicial;
    }

    private IEnumerator Crr_Resetear()
    {
        Resetear();
        yield return new WaitForSeconds(0.1f);
        b_resetear = false;
    }

    public void Reinicio()
    {
        b_resetear = true;
        StartCoroutine(Crr_Resetear());
    }

    private void Reaparicion()
    {
        if (transform.position.y < f_limite_vertical)
        {
            Resetear();
        }
    }

    public void Invertir_Personaje(bool b_invertir_gravedad)
    {
        transform.Rotate(b_invertir_gravedad ? new Vector3(0, 0, 180) : new Vector3(0, 0, -180));
    }
}