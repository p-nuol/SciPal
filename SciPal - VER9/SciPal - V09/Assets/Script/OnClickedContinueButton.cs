using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickedContinueButton : MonoBehaviour
{
    public GameObject optionWindow;

    public void Continued()
    {
        if (optionWindow != null)
        {
            optionWindow.SetActive(false);
        }
    }
}
