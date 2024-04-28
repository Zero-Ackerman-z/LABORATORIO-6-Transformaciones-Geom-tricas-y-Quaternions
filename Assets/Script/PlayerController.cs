using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   private PlayerInputActions controls;
    private Rigidbody rb;
    [SerializeField] float velocidadMovimiento = 5f;
    private Vector2 movimientoInput;
    public float maxInclinacion = 35f; // Máxima inclinación del avión en grados
    public float velocidadRotacion = 10f; // Velocidad de rotación del avión
    
    public GameManager gameManager; 

    private void Awake()
    {
        controls = new PlayerInputActions();
        controls.Game.Move.performed += ctx => Movimiento(ctx);
        controls.Game.Move.canceled += ctx => PararMovimiento();

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        controls.Game.Enable();
    }

    private void OnDisable()
    {
        controls.Game.Disable();
    }

    private void FixedUpdate()
    {
        // Obtener el vector de movimiento en los ejes Y y Z (ignorar el eje X)
        Vector3 movimiento = new Vector3(0f, movimientoInput.y, movimientoInput.x) * velocidadMovimiento * Time.fixedDeltaTime;

        // Mover el Rigidbody en los ejes Y y Z (ignorar el eje X)
        rb.MovePosition(rb.position + new Vector3(0f, movimiento.y, movimiento.z));

        // Calcular la inclinación del avión en función del movimiento
        float inclinacionZ = Mathf.Clamp(-movimientoInput.x * maxInclinacion, -maxInclinacion, maxInclinacion);
        float inclinacionY = Mathf.Clamp(-movimientoInput.y * maxInclinacion, -maxInclinacion, maxInclinacion);

        // Calcular la rotación del avión
        Quaternion targetRotation = Quaternion.Euler(inclinacionZ, 0f, inclinacionY);

        // Aplicar la rotación gradualmente
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, velocidadRotacion * Time.fixedDeltaTime);        

    }

    public void Movimiento(InputAction.CallbackContext context)
    {
        // Obtener el valor de entrada del movimiento horizontal y vertical
        movimientoInput = context.ReadValue<Vector2>();
        // Si el valor de entrada es muy pequeño, considerarlo como cero
        if (Mathf.Abs(movimientoInput.x) < 0.1f)
        {
            movimientoInput.x = 0f;
        }
        if (Mathf.Abs(movimientoInput.y) < 0.1f)
        {
            movimientoInput.y = 0f;
        }
    }
    public void PararMovimiento()
    {
        // Detener el movimiento y la rotación cuando se detiene la entrada de movimiento
        movimientoInput = Vector2.zero;
    }
    
    
    

}
