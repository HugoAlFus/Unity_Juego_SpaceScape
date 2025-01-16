using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidad_atraccion : MonoBehaviour, IVelocidad_Personaje
{
    private Gravedad_Personalizada[] gravedades;
    private Vector3 v3_fuerza_gravedad = Vector3.zero;
    public void Reinicio()
    {
        v3_fuerza_gravedad = Vector3.zero;
    }

    public Vector3 Velocidad(bool b_toca_piso, RaycastHit hit)
    {
        foreach (Gravedad_Personalizada gravedad_Personalizada in gravedades)
        {
            if (b_toca_piso)
            {
                v3_fuerza_gravedad = Vector3.zero;
            }
            else
            {

                if (gravedad_Personalizada.tag == "Gravedad")
                {
                    if (FindObjectOfType<Control_Gravedad>().B_invertir_gravedad)
                        v3_fuerza_gravedad += gravedad_Personalizada.Gravedad_Hacia_Objeto();
                    else
                        v3_fuerza_gravedad = Vector3.zero;
                }
                else
                    v3_fuerza_gravedad += gravedad_Personalizada.Gravedad_Hacia_Objeto();
            }


        }

        //Debug.Log("Fuerza invertida: " + v3_fuerza_gravedad);
        return v3_fuerza_gravedad;
    }

    // Start is called before the first frame update
    void Start()
    {
        gravedades = FindObjectsOfType<Gravedad_Personalizada>();
    }
}
