using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Control_Panel : MonoBehaviour
{
    public Animator a_estado_inicial;

    private int i_parametro_abierto;
    private Animator a_abierto;
    private GameObject go_seleccion_anterior;

    const string s_estado_abierto = "Open";
    const string s_estado_cerrado = "Closed";

    public void OnEnable()
    {
        i_parametro_abierto = Animator.StringToHash(s_estado_abierto);

        if (a_estado_inicial == null)
            return;

        Abrir_Panel(a_estado_inicial);
    }

    public void Abrir_Panel(Animator a_animacion)
    {
        if (a_abierto == a_animacion)
            return;

        a_animacion.gameObject.SetActive(true);
        GameObject go_nueva_seleccion = EventSystem.current.currentSelectedGameObject;

        a_animacion.transform.SetAsLastSibling();

        Cerrar_Actual();

        go_seleccion_anterior = go_nueva_seleccion;

        a_abierto = a_animacion;
        a_abierto.SetBool(i_parametro_abierto, true);

        GameObject go_seleccionado = Buscar_Habilitado(a_animacion.gameObject);

        Set_Seleccionado(go_seleccionado);

    }

    static GameObject Buscar_Habilitado(GameObject go_buscar)
    {
        GameObject go = null;
        Selectable[] se_seleccionados = go_buscar.GetComponentsInChildren<Selectable>(true);
        foreach (Selectable selectable in se_seleccionados)
        {
            if (selectable.IsActive() && selectable.IsInteractable())
            {
                go = selectable.gameObject;
                break;
            }
        }

        return go;
    }

    IEnumerator Deshabilitar_Panel(Animator a_animator)
    {
        bool b_estado_cerrado = false;
        bool b_quiere_cerrar = true;

        while (!b_estado_cerrado && b_quiere_cerrar)
        {
            if (!a_animator.IsInTransition(0))
                b_estado_cerrado = a_animator.GetCurrentAnimatorStateInfo(0).IsName(s_estado_cerrado);

            b_quiere_cerrar = !a_animator.GetBool(i_parametro_abierto);

            yield return new WaitForEndOfFrame();
        }

        if (b_quiere_cerrar)
            a_animator.gameObject.SetActive(false);
    }

    public void Cerrar_Actual()
    {
        if (a_abierto == null)
            return;

        a_abierto.SetBool(i_parametro_abierto, false);
        Set_Seleccionado(go_seleccion_anterior);
        StartCoroutine(Deshabilitar_Panel(a_abierto));
        a_abierto = null;

    }

    private void Set_Seleccionado(GameObject go)
    {
        EventSystem.current.SetSelectedGameObject(go);
    }
}
