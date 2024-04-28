using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObstacleController : MonoBehaviour
{
    private Transform player; // Referencia al jugador
    private Transform planet; // Referencia al planeta orbitará el obstáculo
    private bool chasePlayer = false; // Indicador de si perseguir al jugador o no
    public float chaseRange = 5f; // Rango de distancia para empezar a perseguir 
    public float chaseSpeed = 5f; // Velocidad de movimiento 
    public float orbitSpeed = 30f; // Velocidad de la órbita
    public int damageAmount = 1; // Cantidad de daño  infligido
    public PlayerHealth playerHealth;
    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>(); 

    }
    void Update()
    {
        if (player != null && chasePlayer && Vector3.Distance(transform.position, player.position) <= chaseRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            OrbitAroundPlanet();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);

            }
            Destroy(gameObject);       
        }
    }
    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }

    public void SetPlanet(Transform planetTransform)
    {
        planet = planetTransform;
    }

    private void MoveTowardsPlayer()
    {
        // Mover hacia el jugador
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    private void OrbitAroundPlanet()
    {
        // Rotar alrededor del planeta
        transform.RotateAround(planet.position, -transform.forward, orbitSpeed * Time.deltaTime);
    }

    // Método  modo de persecución
    public void SetChaseMode()
    {
        chasePlayer = true;
    }

    // Método  modo de órbita 
    public void SetOrbitMode()
    {
        chasePlayer = false;
    }
}
