using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int correctAnswers = 0;
    int questionSeen = 0;

    public int GetCorrectAnswers() { return correctAnswers; }
    public int GetQuestionsSeen() { return questionSeen; }

    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }

    public void IncrementQuestionsSeen()
    {
        questionSeen++;
    }

    public int CalculateScore()
    {
        if (questionSeen == 0) return 0;
        return Mathf.RoundToInt((float)correctAnswers / questionSeen * 100);
    }
}
        