using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVelocidad_Personaje
{
    Vector3 Velocidad(bool b_toca_piso, RaycastHit hit);
    void Reinicio();
}
