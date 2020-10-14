using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public static bool ButtonIsClicked = false;
    public GameObject humanLandPreview;
    public GameObject animalLandPreview;
    public GameObject plantLandPreview;
    public GameObject objectLandPreview;

    public void OnClickedXButton()
    {
        humanLandPreview.SetActive(false);
        animalLandPreview.SetActive(false);
        plantLandPreview.SetActive(false);
        objectLandPreview.SetActive(false);
        Time.timeScale = 1f;
        ButtonIsClicked = false;
    }

    public void OnClikedHumanLandButton()
    {
        humanLandPreview.SetActive(true);
        Time.timeScale = 0f;
        ButtonIsClicked = true;
    }

    public void OnClikedAnimalLandButton()
    {
        animalLandPreview.SetActive(true);
        Time.timeScale = 0f;
        ButtonIsClicked = true;
    }

    public void OnClikedPlantLandButton()
    {
        plantLandPreview.SetActive(true);
        Time.timeScale = 0f;
        ButtonIsClicked = true;
    }

    public void OnClikedObjectLandButton()
    {
        objectLandPreview.SetActive(true);
        Time.timeScale = 0f;
        ButtonIsClicked = true;
    }

    public void StartHumanLandGame()
    {

    }

    public void StartAnimalLandGame()
    {

    }

    public void StartPlantLandGame()
    {

    }

    public void StartObjectLandGame()
    {
        SceneManager.LoadScene("ObjectLand");
    }
}
