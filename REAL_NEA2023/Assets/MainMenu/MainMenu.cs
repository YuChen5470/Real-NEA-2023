using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
    SceneManager.LoadScene("Game"); // loads game scene
    }
    public void Quit()
    {
        Application.Quit(); //quits application
        Debug.Log("Quit"); // outputs "quit" into console
    }
}
