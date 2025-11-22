using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GeneracionEnemigos : MonoBehaviour
{
    [Header("Puntos de inicio de los enemigos")]
    public Transform parentObjectEnemigos;
    public Transform[] puntosInicio;
    public GameObject enemigo1;
    public GameObject enemigo2;


    [Header("Ajustes de dificultad")]
    public TimerEnemigo timerEnemigo;
    public float refrescoEnemigos = 1.0f;
    public float velocidadEnemigo = 3.5f;
    public float dificultadEnemigo = 0;

    void Start()
    {
        timerEnemigo = FindAnyObjectByType<TimerEnemigo>();

        int dificultad = PlayerPrefs.GetInt("dificultad", 1);

        if (dificultad == 0) // Baja
        {
            refrescoEnemigos = 3.0f;
            velocidadEnemigo = 2.5f;
        }
        else if (dificultad == 1) // Media
        {
            refrescoEnemigos = 2.0f;
            velocidadEnemigo = 3.5f;
        }
        else if (dificultad == 2) // Alta
        {
            refrescoEnemigos = 1.0f;
            velocidadEnemigo = 5.0f;
        }

        StartCoroutine("DificultadCreacionEnemigo");
    }

    void Update()
    {
        // progresion por tiempo en dificultad media
        int dificultad = PlayerPrefs.GetInt("dificultad", 1);

        if (dificultad == 1)
        {
            dificultadEnemigo = timerEnemigo.getTimerEnemigo();

            if (dificultadEnemigo > 0 && dificultadEnemigo < 30)
            {
                refrescoEnemigos = 2.0f;
                velocidadEnemigo = 3.5f;
            }
            else if (dificultadEnemigo >= 30 && dificultadEnemigo < 60)
            {
                refrescoEnemigos = 1.0f;
                velocidadEnemigo = 4.0f;
            }
            else if (dificultadEnemigo >= 60)
            {
                refrescoEnemigos = 0.5f;
                velocidadEnemigo = 4.5f;
            }
        }
    }

    IEnumerator DificultadCreacionEnemigo()
    {
        yield return new WaitForSeconds(refrescoEnemigos);
        CreaEnemigo();
        StartCoroutine("DificultadCreacionEnemigo");
    }

    void CreaEnemigo()
    {
        int aleatorioPuntosInicio = Random.Range(0, puntosInicio.Length);
        GameObject enemigoSeleccionado;

        int aleatorioTipo = Random.Range(0, 2);
        if (aleatorioTipo == 0)
        {
            enemigoSeleccionado = enemigo1;
        }
        else
        {
            enemigoSeleccionado = enemigo2;
        }

        GameObject nuevoEnemigo;
        nuevoEnemigo = Instantiate(enemigoSeleccionado,
            puntosInicio[aleatorioPuntosInicio].position,
            puntosInicio[aleatorioPuntosInicio].rotation,
            parentObjectEnemigos);

        NavMeshAgent agent = nuevoEnemigo.GetComponent<NavMeshAgent>();
        agent.speed = velocidadEnemigo;
    }


    public void DestruirTodosLosEnemigos()
    {
        if (parentObjectEnemigos != null)
        {
            foreach (Transform enemigo in parentObjectEnemigos)
            {
                Destroy(enemigo.gameObject);
            }
        }
    }
}
