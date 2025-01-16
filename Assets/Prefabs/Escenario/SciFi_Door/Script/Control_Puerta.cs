using UnityEngine;
using System.Collections;

public class door : MonoBehaviour
{
    private GameObject go_puerta;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player" && obj.transform.GetComponentInChildren<IHabilidad>() != null)
        {
            go_puerta = GameObject.FindWithTag("SF_Door");
            go_puerta.GetComponent<Animation>().Play("open");
        }


    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "Player" && obj.transform.GetComponentInChildren<IHabilidad>() != null)
        {
            go_puerta = GameObject.FindWithTag("SF_Door");
            go_puerta.GetComponent<Animation>().Play("close");
        }
    }
}