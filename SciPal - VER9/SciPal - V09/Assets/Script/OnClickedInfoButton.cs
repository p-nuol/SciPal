using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickedInfoButton : MonoBehaviour
{
    public void CreditInfoScene()
    {
        SceneManager.LoadScene("CreditInfo");
    }
}
