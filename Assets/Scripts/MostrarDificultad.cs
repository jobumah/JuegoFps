using UnityEngine;
using TMPro;

public class MostrarDificultad : MonoBehaviour
{
    public TMP_Text texto;

    void Start()
    {
        int dificultad = PlayerPrefs.GetInt("dificultad", 1);

        if (dificultad == 0) texto.text = "Dificultad: Baja";
        else if (dificultad == 1) texto.text = "Dificultad: Media";
        else if (dificultad == 2) texto.text = "Dificultad: Alta";
    }
}
