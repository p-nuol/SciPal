using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class DataController : MonoBehaviour
{
    [SerializeField]private RoundData[] allRoundData;

    private string gameDataFileName = "test.json";

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Loader();
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
            //var loadedImage = Resources.Load<Sprite>("");

            allRoundData = loadedData.allRoundData;
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
    private void Sorting()
    {
        //ReShuffle(); for shuffle data
        //for loop for sorting 10 questions here
        for (int i = 0; i < 10; i++)
        {
            //insert to Question questions?
        }
    }

    /*void ReShuffle(string[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            string tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }*/
}
