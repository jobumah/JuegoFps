using UnityEngine;

public class CajaVida : MonoBehaviour
{
    private GeneracionCajaVida generador;
    private Vida vidaManager;

    void Start()
    {
        generador = FindAnyObjectByType<GeneracionCajaVida>();
        vidaManager = FindAnyObjectByType<Vida>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            vidaManager.AñadirVida();
            generador.CajaRecogida();
            Destroy(gameObject);
        }
    }
}
