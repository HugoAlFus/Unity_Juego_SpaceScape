using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float f_tiempo_vida = 4f;
    public float f_velcidad = 100f;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * f_velcidad;
        Destroy(gameObject.transform.parent.gameObject, f_tiempo_vida);
    }

}
