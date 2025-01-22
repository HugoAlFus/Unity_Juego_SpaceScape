using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control_Aplicacion : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void Salir()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
		Application.Quit();
        #endif
    }

    public void Cargar_Escena(int i_id_escena)
    {
        SceneManager.LoadScene(i_id_escena);
    }
}
