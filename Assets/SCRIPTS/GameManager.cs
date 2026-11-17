using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // los dos textos del canvas
    public TextMeshProUGUI pointLeft;
    public AudioClip pointScoredSound;
    AudioSource _audioSource;
    public AudioClip winSound;
    public TextMeshProUGUI pointRight;

    public GameObject winPanel;

    // Las 2 variables numéricas: los puntos de cada jugador
    public int puntosP1 = 0;
    public int puntosP2 = 0;
    public int puntosParaGanar = 5;

    public void Start()
    {
        Time.timeScale = 1f;

        ActualizarMarcador();
        _audioSource = GetComponent<AudioSource>();

        winPanel.SetActive(false);
    }

    // Llama a esta función cuando el jugador 1 marque un punto
    public void SumarPuntoP1()
    {
        puntosP1++;
        ComprobarFinal(GetWinSound());
        ActualizarMarcador();
    }

    // Llama a esta función cuando el jugador 2 marque un punto
    public void SumarPuntoP2()
    {
        puntosP2++;
        ComprobarFinal(GetWinSound());
        ActualizarMarcador();
    }

    // Pasa los números a texto y los muestra en pantalla
    public void ActualizarMarcador()
    {
        pointLeft.text = "" + puntosP1;
        pointRight.text = "" + puntosP2;

        Debug.Log("Marcador: " + puntosP1 + " | " + puntosP2);
    }

    private AudioClip GetWinSound()
    {
        return winSound;
    }
    
    void ComprobarFinal(AudioClip winSound)
    {
        if (puntosP1 >= puntosParaGanar || puntosP2 >= puntosParaGanar)
        {
            winPanel.SetActive(true);

            _audioSource.clip = winSound;
            _audioSource.Play();

            Time.timeScale = 0f;
        }
    }

}
