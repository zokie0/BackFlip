using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void endless()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void twoplayer()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
}
