using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickedHomeButton : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject optionWindow;

    public void Resume()
    {
        optionWindow.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        optionWindow.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
