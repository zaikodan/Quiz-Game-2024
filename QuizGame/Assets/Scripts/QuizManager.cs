using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    private Quiz[] quizList;
    private Quiz currentQuiz;

    public void SelectQuiz(Quiz.Theme themeSelected, Quiz.Dificulty dificultySelected)
    {
        Quiz quiz = quizList[Random.Range(0, quizList.Length)];
        if(quiz.GetDificulty == dificultySelected && quiz.GetTheme == themeSelected)
        {
            currentQuiz = quiz;
        }
        else
        {
            SelectQuiz(themeSelected, dificultySelected);
        }
    }
}
