using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{

    // Use this for initialization
    public void play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("scene1");
    }
    public void quit()
    {
        Application.Quit();
    }
}
