using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject go_proyectil;
    public Transform t_punto_disparo;
    public float f_tiempo_disparo = 5f;

    private float f_tiempo_transcurrido;
  
    void Update()
    {
        f_tiempo_transcurrido += Time.deltaTime;

        if(f_tiempo_transcurrido >= f_tiempo_disparo)
        {
            f_tiempo_transcurrido = 0;
            Debug.Log("Disparo");
            Disparo();

        }
        
    }

    private void Disparo()
    {
        Instantiate(go_proyectil, t_punto_disparo.position, t_punto_disparo.rotation);
    }
}
