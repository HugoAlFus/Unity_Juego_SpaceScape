using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_animacion : MonoBehaviour, IAnimacion
{
    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Animar_Por_Velocidad(Vector3 v3_velocidad)
    {
        animator.SetFloat("velocidad_movimiento", v3_velocidad.z);
    }

    public void Animar_Salto()
    {
        animator.SetTrigger("salto");
    }
}
