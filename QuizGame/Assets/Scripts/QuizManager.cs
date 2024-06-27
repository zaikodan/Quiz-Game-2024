using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    #region Singleton
    public static QuizManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

    }
    #endregion

    int rightAnswer;

    [SerializeField] private Quiz[] quizList;
    [SerializeField] private Quiz currentQuiz;

    public void SelectQuiz(Quiz.Theme themeSelected, Quiz.Difficulty dificultySelected)
    {
        Quiz quiz = quizList[Random.Range(0, quizList.Length)];
        if(quiz.GetDifficulty == dificultySelected && quiz.GetTheme == themeSelected)
        {
            currentQuiz = quiz;
            UIManager.instance.UpdateQuestion(currentQuiz);
        }
        else
        {
            SelectQuiz(themeSelected, dificultySelected);
        }
    }

    public void CheckAnswer(int answerSelected)
    {
        if(answerSelected == currentQuiz.CorrectAnswer)
        {
            rightAnswer++;
        }
        else
        {
            GameManager.Instance.GameOver();    
        }

        UIManager.instance.HighlightButton(currentQuiz.CorrectAnswer, answerSelected);
    }
}
