using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Número máximo de golpes que puede recibir el jugador
    private int currentHealth; // Vida actual del jugador
    public UnityEvent OnPlayerDeath; // Evento que se dispara cuando el jugador muere

    private void Start()
    {
        currentHealth = maxHealth; // Al inicio del juego, la vida actual es igual a la vida máxima
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; 
        if (currentHealth <= 0)
        {
            OnPlayerDeath?.Invoke(); // Invocar el evento si la salud llega a cero 
        
        }
        
    }
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
