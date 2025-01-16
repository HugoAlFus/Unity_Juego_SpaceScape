using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Control_Gravedad : MonoBehaviour, IHabilidad
{
    public Material mat_desactivado;
    public Material mat_activado;
    public Button btn_habilidad;

    private Control control;
    private bool b_invertir_gravedad = false;
    private float f_ultima_accion = -Mathf.Infinity;
    private float f_cooldown = 3.5f;

    public bool B_invertir_gravedad { get => b_invertir_gravedad; set => b_invertir_gravedad = value; }

    private void Start()
    {
        control = FindObjectOfType<Control>();
    }

    public void Activar_habilidad()
    {
        if (control != null)
        {
            if (Time.time >= f_ultima_accion + f_cooldown)
            {
                control.Cambiar_Gravedad();
                B_invertir_gravedad = !B_invertir_gravedad;
                FindObjectOfType<Control_Personaje>().Invertir_Personaje(B_invertir_gravedad);
                Cambiar_Color();
                f_ultima_accion = Time.time;
            }
        }

    }

    private void Update()
    {
        if (Time.time >= f_ultima_accion + f_cooldown)
            btn_habilidad.GetComponent<Image>().color = Color.green;
        else
            btn_habilidad.GetComponent<Image>().color = Color.red;
    }

    private void Cambiar_Color()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            if (renderer.tag == "Cambiar_color")
            {
                if (!B_invertir_gravedad)
                    renderer.material = mat_desactivado;
                else
                    renderer.material = mat_activado;


            }
        }
    }

    public void Reinicio()
    {
        B_invertir_gravedad = false;

        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            if (renderer.tag == "Cambiar_color")
            {
                    renderer.material = mat_desactivado;;
            }
        }

        if (Physics.gravity.y > 0)
        {
            Physics.gravity *= -1;
        }
    }
}
