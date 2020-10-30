using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public struct ChoiceOfQuestion
    {
        public bool isCorrect;
        public Sprite ChoiceImg;
        public string Choice;
    }

    [System.Serializable]
    public struct Question
    {
        public bool isAlready;
        public int Score;
        public string StrQuestion;
        public Sprite ImageQuestion;
        public ChoiceOfQuestion[] Choice;
    }

    public Question[] SystemQuestion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextQuestion()
    {
  /*      var ran = Random.Range(0, SystemQuestion.Length);
        var isAlready = SystemQuestion[ran].isAlready;
        if(isAlready)
        {

        }*/




        for (int i = 0; i < SystemQuestion.Length; i++)
        {

        }
    }
}
