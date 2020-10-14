using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickedXButton : MonoBehaviour
{
    public void BacktoMap() {
        SceneManager.LoadScene("Map");
    }
}
