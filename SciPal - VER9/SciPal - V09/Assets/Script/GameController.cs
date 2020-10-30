using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text questionText;
    public Image questionImage;
    public Text knowledgeText;
    public Image knowledgeImage;
    public Text itemNumberDisplay;
    public Text scoreDisplay;
    public Image starDisplay;
    public Sprite[] stars;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject resultDisplay;
    public GameObject knowledgeDisplay;
    public GameObject tryAgainButton;
    public Sprite correctAnswer;
    public Sprite wrongAnswer;
    public Button answerButton;
    //public Sprite correctSprite;
    //public Sprite wrongSprite;

    private DataController dataController;
    private RoundData currentRoundData;
    private Question[] questionPool;

    private bool isRoundActive;
    private int questionIndex;
    private int score;
    private int itemNumber;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    [SerializeField] private Sprite ImgQuestion;

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
        //knowledgeText.text = question.correctKnowledge.title;

        for (int i = 0; i < question.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            
            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.SetUp(question.answers[i]);

            questionImage.sprite = ImgQuestion;
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
            //answerButton.image.sprite = correctAnswer;
            ShowKnowledge();
        }
        else
        {
            //answerButton.image.sprite = wrongAnswer;
            ShowKnowledge();
        }
    }

    public void OnClickedAcceptButton()
    {
        knowledgeDisplay.SetActive(false);

        if (questionPool.Length > questionIndex + 1)
        {
            questionIndex++;

            ShowQuestion();
            //re-count timer here?
        }
        else
        {
            EndRound();
        }

        itemNumber += 1;
        itemNumberDisplay.text = itemNumber.ToString() + "/10";
    }

    public void ShowKnowledge()
    {
        knowledgeDisplay.SetActive(true);

        switch (score)
        {
            case 0:
                starDisplay.sprite = stars[0];
                break;
            case 1:
                starDisplay.sprite = stars[1];
                break;
            case 2:
                starDisplay.sprite = stars[2];
                break;
            case 3:
                starDisplay.sprite = stars[3];
                break;
            case 4:
                starDisplay.sprite = stars[4];
                break;
            case 5:
                starDisplay.sprite = stars[5];
                break;
            case 6:
                starDisplay.sprite = stars[6];
                break;
            case 7:
                starDisplay.sprite = stars[7];
                break;
            case 8:
                starDisplay.sprite = stars[8];
                break;
            case 9:
                starDisplay.sprite = stars[9];
                break;
            case 10:
                starDisplay.sprite = stars[10];
                break;
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("ObjectLand");
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
