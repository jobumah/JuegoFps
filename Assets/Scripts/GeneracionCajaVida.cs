using System.Collections.Generic;
using UnityEngine;

public class GeneracionCajaVida : MonoBehaviour
{
    public Transform[] puntosCajaVida;
    public GameObject cajaVidaPrefab;
    public Transform parentObjectCajaVida;

    public List<int> puntosDisponibles = new List<int>();
    private int ultimoPunto = -1;
    private GameObject cajaActual;

    public int maxCajas = 1;
    public int cajasActuales = 0;

    void Start()
    {
        for (int i = 0; i < puntosCajaVida.Length; i++)
        {
            puntosDisponibles.Add(i);
        }

        int dificultad = PlayerPrefs.GetInt("dificultad", 1);

        if (dificultad == 0) maxCajas = 3;  // Baja
        else if (dificultad == 1) maxCajas = 2; // Media
        else if (dificultad == 2) maxCajas = 1; // Alta

        SpawnCaja();
    }

    public void CajaRecogida()
    {
        Debug.Log("Caja recogida en posicion " + ultimoPunto);
        puntosDisponibles.Add(ultimoPunto);
        ultimoPunto = -1;
        Destroy(cajaActual);
        cajasActuales--;

        SpawnCaja();
    }

    public void SpawnCaja()
    {
        if (cajasActuales >= maxCajas) return;

        List<int> puntosValidos = new List<int>(puntosDisponibles);

        if (ultimoPunto != -1)
        {
            puntosValidos.Remove(ultimoPunto);
        }

        int puntoRandom = puntosValidos[Random.Range(0, puntosValidos.Count)];
        ultimoPunto = puntoRandom;

        cajaActual = Instantiate(cajaVidaPrefab,puntosCajaVida[puntoRandom].position,puntosCajaVida[puntoRandom].rotation,parentObjectCajaVida);

        puntosDisponibles.Remove(puntoRandom);

        cajasActuales++;
    }
}
