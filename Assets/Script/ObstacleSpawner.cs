using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public ObstacleData[] obstacleDatas; // Array de ScriptableObjects
    public Transform player; 
    public Transform planet; // planeta alrededor del cual orbitar�n los obst�culos
    public float spawnInterval = 2f; // Intervalo de tiempo entre la creaci�n de obst�culos
    public float obstacleLifetime = 2f; // Tiempo de vida del obst�culo antes de ser destruido
    public float spawnRadius = 5f; // Radio dentro del cual instanciar los obst�culos

    private void Start()
    {
        // Comenzar a instanciar obst�culos cada cierto intervalo de tiempo
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

    private void SpawnObstacle()
    {
        // Calcular una posici�n aleatoria dentro del rango especificado
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

        // Elegir un ObstacleData aleatorio de la lista
        ObstacleData chosenObstacleData = obstacleDatas[Random.Range(0, obstacleDatas.Length)];

        // Instanciar un nuevo obst�culo utilizando el ObstacleData elegido en la posici�n aleatoria
        GameObject obstacleInstance = Instantiate(chosenObstacleData.prefab, spawnPosition, Quaternion.identity);

        // Obtener el componente ObstacleController del objeto instanciado
        ObstacleController obstacleController = obstacleInstance.GetComponent<ObstacleController>();

        // Configurar las propiedades del obst�culo utilizando el ObstacleData
        obstacleController.chaseRange = chosenObstacleData.chaseRange;
        obstacleController.chaseSpeed = chosenObstacleData.chaseSpeed;
        obstacleController.orbitSpeed = chosenObstacleData.orbitSpeed;
        obstacleController.SetPlayer(player); // Configurar la referencia al jugador
        obstacleController.SetPlanet(planet); // Configurar la referencia al planeta
        obstacleController.SetOrbitMode(); // Configurar el obst�culo para que solo orbite

        // Destruir el obst�culo despu�s de un cierto tiempo de vida
        Destroy(obstacleInstance, obstacleLifetime);
    }
    private void OnDrawGizmosSelected()
    {
        // Dibujar un gizmo esf�rico para representar el rango de spawn
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnRadius * 2, spawnRadius * 2, spawnRadius * 4));
    }
}
