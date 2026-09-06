using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header("Button Sprites")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image  timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;

        // Check if the timer has finished and we need to load the next question
        if (timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            timer.loadNextQuestion = false;
            GetNextQuestion();
        }
        // Check if the user has answered the question early
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    private void DisPlayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = $"Score : {scoreManager.CalculateScore()}%";
    }

    private void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct Answer!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreManager.IncrementCorrectAnswers();
        }
        else
        {
            questionText.text = $"Answer is {currentQuestion.GetAnswer(currentQuestion.GetCorrectAnswerIndex())}";
            buttonImage = answerButtons[currentQuestion.GetCorrectAnswerIndex()].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0;i < answerButtons.Length;i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void GetNextQuestion()
    {
        if(questions.Count == 0)
        {
            Debug.Log("Out of questions");
            return;
        }
        SetButtonState(true);
        SetDefaultButtonSprites();
        GetRandomQuestion();
        DisPlayQuestion();
        scoreManager.IncrementQuestionsSeen();
    }

    private void GetRandomQuestion()
    {
        int index = Random.Range(0,questions.Count);
        currentQuestion = questions[index];

        if(questions.Contains(currentQuestion)) 
        {
            questions.Remove(currentQuestion);
        }
    }

    private void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
