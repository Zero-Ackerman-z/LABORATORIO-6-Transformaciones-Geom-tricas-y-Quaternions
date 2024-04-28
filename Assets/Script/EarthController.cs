using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f; // Velocidad de rotación de la Tierra

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotar la Tierra lentamente en el eje Y
        transform.Rotate(-transform.forward, rotationSpeed * Time.deltaTime);
    }
}
