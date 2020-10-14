using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class DataController : MonoBehaviour
{
    private RoundData[] allRoundData;

    private string gameDataFileName = "objquestion.json";

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Loader();

        //SceneManager.LoadScene("Map");
    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }

    private void Loader()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

            allRoundData = loadedData.allRoundData;
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
}
