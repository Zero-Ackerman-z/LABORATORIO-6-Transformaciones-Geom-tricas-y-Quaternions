using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public GameObject loserPanel;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        // Verificar si ya hay una instancia existente
        if (_instance != null && _instance != this)
        {
            // Si ya existe una instancia, destruir este objeto para evitar duplicados
            Destroy(this.gameObject);
        }
        else
        {
            // Establecer esta instancia como la única instancia
            _instance = this;
            // Asegurar que este objeto no se destruya al cargar una nueva escena
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start()
    {
        // Desactivar el panel de "perdedor" al inicio del juego
        loserPanel.SetActive(false);
    }


    //  mostrar el panel de "perdedor"
    private void ShowLoserPanel()
    {
        loserPanel.SetActive(true);
    }

    // cerrar el juego
    public void QuitGame()
    {
        // Pausar el juego 
        Time.timeScale = 0f;
        ShowLoserPanel();

    }
    
}