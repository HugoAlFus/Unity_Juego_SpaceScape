using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Control_Musica : MonoBehaviour
{
    [Header("Sliders de Volumen")]
    public Slider sliderVolumenMaestro;
    public Slider sliderMusica;
    public Slider sliderEfectos;

    [Header("Audio Mixer")]
    public AudioMixer audioMixer;

    private const float F_ValorPredeterminadoVolumen = 50f;

    void Start()
    {

        Cargar_Valores_Audio();
    }

    public void Cambiar_Valor_Audio()
    {
        PlayerPrefs.SetFloat("volumenMaestro", sliderVolumenMaestro.value);
        PlayerPrefs.SetFloat("volumenMusica", sliderMusica.value);
        PlayerPrefs.SetFloat("volumenEfectos", sliderEfectos.value);

        audioMixer.SetFloat("VolumenMaestro", Convertir_Volumen(sliderVolumenMaestro.value));
        audioMixer.SetFloat("VolumenMusica", Convertir_Volumen(sliderMusica.value));
        audioMixer.SetFloat("VolumenEfectos", Convertir_Volumen(sliderEfectos.value));

        PlayerPrefs.Save();
    }

    private void Cargar_Valores_Audio()
    {
        sliderVolumenMaestro.value = PlayerPrefs.GetFloat("volumenMaestro", F_ValorPredeterminadoVolumen);
        sliderMusica.value = PlayerPrefs.GetFloat("volumenMusica", F_ValorPredeterminadoVolumen);
        sliderEfectos.value = PlayerPrefs.GetFloat("volumenEfectos", F_ValorPredeterminadoVolumen);

        audioMixer.SetFloat("VolumenMaestro", Convertir_Volumen(sliderVolumenMaestro.value));
        audioMixer.SetFloat("VolumenMusica", Convertir_Volumen(sliderMusica.value));
        audioMixer.SetFloat("VolumenEfectos", Convertir_Volumen(sliderEfectos.value));
    }

    private float Convertir_Volumen(float valorSlider)
    {
        return Mathf.Log10(Mathf.Clamp(valorSlider, 0.01f, 100f)) * 20f;
    }
}
