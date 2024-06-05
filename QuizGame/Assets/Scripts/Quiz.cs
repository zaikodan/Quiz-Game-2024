using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuiz", menuName = "Quiz")]
public class Quiz : ScriptableObject
{
    [SerializeField, TextArea]
    private string question;
    [SerializeField]
    private string[] answers = new string[4];
    [SerializeField]
    private int correctAnswer;
    [SerializeField]
    private Theme theme;
    [SerializeField]
    private Dificulty dificulty;


    public string Question { get => question; }
    public string[] Answers { get => answers; }
    public Theme GetTheme { get => theme; }
    public Dificulty GetDificulty { get => dificulty; }

    public enum Theme { Portuguese, Math, Geography};
    public enum Dificulty { Easy, Medium, Hard};

    public bool CheckAnswer(int answerSelected)
    {
        return answerSelected == correctAnswer;
    }
}
