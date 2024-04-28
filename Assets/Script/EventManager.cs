using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void Start()
    {
        // Suscribir
        if (playerHealth != null)
        {
            playerHealth.OnPlayerDeath.AddListener(HandlePlayerDeath);

        }
        else
        {
            Debug.LogError("PlayerHealth no está asignado en el EventManager.");
        }
    }

    public void HandlePlayerDeath()
    {
        Debug.Log("El jugador ha muerto.");
        GameManager.Instance.QuitGame();
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnPlayerDeath.RemoveListener(HandlePlayerDeath);
        }
    }
}