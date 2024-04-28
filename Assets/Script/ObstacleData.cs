using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewObstacle", menuName = "Obstacle")]

public class ObstacleData : ScriptableObject
{
    public GameObject prefab; 
    public float chaseRange = 10f; // Rango de distancia para perseguir 
    public float chaseSpeed = 5f; // Velocidad de movimiento hacia el jugador
    public float orbitSpeed = 30f; // Velocidad de la órbita
}

