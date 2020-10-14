using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text questionText;
    public Image questionImage;
    public Text itemNumberDisplay;
    public Text scoreDisplay;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject resultDisplay;

    private DataController dataController;
    private RoundData currentRoundData;
    private Question[] questionPool;

    private bool isRoundActive;
    private int questionIndex;
    private int score;
    private int itemNumber;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();


    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        //what about time remaining at timeer bar? >> just move TimerScript here and just use Timer();

        score = 0;
        questionIndex = 0; //maybe we have to do smthng abt shuffle index here?
        itemNumber = 1;

        ShowQuestion();
        isRoundActive = true;
    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        Question question = questionPool[questionIndex];
        questionText.text = question.info;

        for (int i = 0; i < question.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            
            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.SetUp(question.answers[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while(answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }


    public void OnClickedAnswerButton(bool isCorrect)
    {
        if (isCorrect)
        {
            score += currentRoundData.scoreOfCorrectAns;
        }

        if (questionPool.Length > questionIndex +1)
        {
            questionIndex++;
            ShowQuestion();
            //re-count timer here?
        }
        else
        {
            EndRound();
        } //maybe this if-else should be moved to ShowKnowledge()

        //show knowledge here

        itemNumber += 1;
        itemNumberDisplay.text = itemNumber.ToString() + "/10";
    }

    public void ShowKnowledge()
    {

    }

    public void EndRound()
    {
        isRoundActive = false;
        scoreDisplay.text = score.ToString() + "/10";

        questionDisplay.SetActive(false);
        resultDisplay.SetActive(true);
    }

    public void ReturnToMap()
    {
        SceneManager.LoadScene("Map");
    }
}
