using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Usar_Habilidad : MonoBehaviour
{
    public KeyCode kc_activar;
    public Transform t_punto_habilidad;

    private IHabilidad habilidad;
    private GameObject go_habilidad;

    void Update()
    {
        if (Input.GetKeyDown(kc_activar))
            Activar();

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Habilidad" && go_habilidad == null)
        {
            habilidad = hit.transform.GetComponent<IHabilidad>();
            go_habilidad = hit.gameObject;
            Agarrar_Habilidad();
        }
    }

    private void Agarrar_Habilidad()
    {
        go_habilidad.transform.position = t_punto_habilidad.position;
        go_habilidad.transform.rotation = t_punto_habilidad.rotation;
        go_habilidad.transform.parent = transform;

        go_habilidad.GetComponentInChildren<Canvas>(true).gameObject.SetActive(true);
    }

    public void Activar()
    {
        if (go_habilidad != null)
            habilidad.Activar_habilidad();
    }
}
