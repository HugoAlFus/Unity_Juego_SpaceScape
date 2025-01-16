using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float f_duracion = 1f;

    private Light luz;
    private Color c_rojo = new Color(0.9921569f, 0.5921569f, 0.6f, 1f);
    private Color c_blanco = Color.white;
    public void Reinicio()
    {
        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            IReinicio reinicio = go.GetComponent<IReinicio>();
            if (reinicio != null)
                reinicio.Reinicio();
        }
    }


    public void Cambiar_Gravedad()
    {
        Physics.gravity *= -1;

        foreach (Velocidad_Vertical velocidad in FindObjectsOfType<Velocidad_Vertical>())
        {
            velocidad.Reinicio();
        }
    }

    private void Update()
    {
        float f_tiempo = Mathf.PingPong(Time.time, f_duracion) / f_duracion;
        luz.color = Color.Lerp(c_rojo, c_blanco, f_tiempo);

    }

    private void Start()
    {
        luz = GameObject.FindGameObjectWithTag("Luz_global").GetComponent<Light>();
    }
}
