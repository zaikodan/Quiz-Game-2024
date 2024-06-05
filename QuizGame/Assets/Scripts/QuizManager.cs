using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private Quiz[] quizList;
    [SerializeField] private Quiz currentQuiz;

    [SerializeField] Quiz.Dificulty dificulty;
    [SerializeField] Quiz.Theme theme;

    public void SelectQuiz(Quiz.Theme themeSelected, Quiz.Dificulty dificultySelected)
    {
        Quiz quiz = quizList[Random.Range(0, quizList.Length)];
        if(quiz.GetDificulty == dificultySelected && quiz.GetTheme == themeSelected)
        {
            currentQuiz = quiz;
            UIManager.instance.UpdateQuestion(currentQuiz);
        }
        else
        {
            SelectQuiz(themeSelected, dificultySelected);
        }
    }

    private void Start()
    {
        SelectQuiz(theme, dificulty);
    }
}
