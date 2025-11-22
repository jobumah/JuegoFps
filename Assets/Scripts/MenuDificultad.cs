using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDificultad : MonoBehaviour
{
    public void DificultadBaja()
    {
        PlayerPrefs.SetInt("dificultad", 0);
        SceneManager.LoadScene(1);
    }

    public void DificultadMedia()
    {
        PlayerPrefs.SetInt("dificultad", 1);
        SceneManager.LoadScene(1);
    }

    public void DificultadAlta()
    {
        PlayerPrefs.SetInt("dificultad", 2);
        SceneManager.LoadScene(1);
    }

    public void Volver()
    {
        SceneManager.LoadScene(0);
    }
}
