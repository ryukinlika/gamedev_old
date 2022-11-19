using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{

    // Use this for initialization
    public static bool paused = false;
    public GameObject pauseUI;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                resume();
            }
            else pause();
        }
    }

    public void resume()
    {
        player.GetComponent<PlayerAttack>().enabled = true;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
    void pause()
    {
        player.GetComponent<PlayerAttack>().enabled = false;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;

    }
    public void quitG()
    {
        Application.Quit();
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("main menu");
    }
}
