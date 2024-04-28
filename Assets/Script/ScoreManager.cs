using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float scoreIncreaseRate = 1f; // Tasa de aumento del puntaje por segundo
    private float currentScore = 0f; // Puntaje actual del jugador

    private void Start()
    {
        // Comenzar a aumentar el puntaje cada segundo
        InvokeRepeating("IncreaseScore", 1f, 1f);
    }
    
    private void IncreaseScore()
    {
        // Aumentar el puntaje según la tasa de aumento
        currentScore += scoreIncreaseRate;
    }

    // Método para obtener el puntaje actual
    public float GetCurrentScore()
    {
        return currentScore;
    }
}
