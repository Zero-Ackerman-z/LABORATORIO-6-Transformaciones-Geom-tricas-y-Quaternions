using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // TextMeshPro para mostrar la puntuación del jugador
    public TextMeshProUGUI collisionCountText; // TextMeshPro para mostrar la collicion del jugador
    public PlayerHealth playerHealth; 
    public ScoreManager scoreManager;

    private void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("¡No se ha asignado el PlayerHealth en el UIManager!");
        }
        if (scoreManager == null)
        {
            Debug.LogError("¡No se ha asignado el ScoreManager en el UIManager!");
        }
    }

    private void Update()
    {
        // Actualizar el texto de la puntuación
        UpdateScore();
        UpdateCollisionCount();

    }
    private void UpdateScore()
    {
        if (scoreText == null)
        {
            Debug.LogError("¡No se ha asignado el TextMeshPro en el UIManager!");
            return;
        }
        if (scoreManager == null)
        {
            Debug.LogError("¡No se ha asignado el ScoreManager en el UIManager!");
            return;
        }

        // Actualizar el texto de la puntuación con el puntaje actual del ScoreManager
        scoreText.text = "Score: " + scoreManager.GetCurrentScore().ToString();
    }
    private void UpdateCollisionCount()
    {
        if (collisionCountText == null)
        {
            Debug.LogError("¡No se ha asignado el TextMeshPro de cantidad de colisiones en el UIManager!");
            return;
        }

        if (playerHealth == null)
        {
            Debug.LogError("¡No se ha asignado el PlayerHealth en el UIManager!");
            return;
        }

        // Actualizar el texto de cantidad de colisiones con la salud actual del jugador
        collisionCountText.text = "Health: " + playerHealth.GetCurrentHealth().ToString();
    }


}
