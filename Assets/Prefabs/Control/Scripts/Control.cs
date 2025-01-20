using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float f_duracion = 1f;

    private Light luz;
    private Color c_rojo = new Color(0.9921569f, 0.5921569f, 0.6f, 1f);
    private Color c_blanco = Color.white;
    private bool b_apagar_luces;

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
        if (!b_apagar_luces)
        {
            float f_tiempo = Mathf.PingPong(Time.time, f_duracion) / f_duracion;
            luz.color = Color.Lerp(c_rojo, c_blanco, f_tiempo);
        }

    }

    public void Apagar_Luces_Intermitentes()
    {
        b_apagar_luces = true;
        luz.color = c_blanco;

    }


    private void Start()
    {
        b_apagar_luces = false;
        luz = GameObject.FindGameObjectWithTag("Luz_global").GetComponent<Light>();
    }
}
