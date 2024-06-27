using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]Button[] answersButtons;
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField]GameObject menuWindow;
    [SerializeField] Button startButton, nextButton;
    [SerializeField] TMP_Dropdown difficultyDropdown, themeDropdown;

    private void Start()
    {
        startButton.onClick.AddListener(() => GameManager.Instance.StartGame(difficultyDropdown.value, themeDropdown.value));
        nextButton.onClick.AddListener(() => QuizManager.instance.SelectQuiz(GameManager.Instance.Theme, GameManager.Instance.Difficulty));

        for(int y = 0; y < answersButtons.Length; y++)
        {
            int x = y;
            answersButtons[y].onClick.AddListener(() => QuizManager.instance.CheckAnswer(x));
            answersButtons[y].onClick.AddListener(() => nextButton.interactable = true);
        }
    }

    public void UpdateQuestion(Quiz quizSelected)
    {
        questionText.text = quizSelected.Question;

        for(int i = 0; i < answersButtons.Length; i++)
        {
            answersButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = quizSelected.Answers[i];
            answersButtons[i].interactable = true;
            answersButtons[i].GetComponent<Image>().color = Color.white;
        }

        nextButton.interactable = false;
    }

    public void SetMenu(bool active)
    {
        menuWindow.SetActive(active);
    }

    public void HighlightButton(int correctAnswer, int answerSelected)
    {
        answersButtons[correctAnswer].GetComponent<Image>().color = Color.green;
        if(answerSelected != correctAnswer)
        {
            answersButtons[answerSelected].GetComponent<Image>().color = Color.red;
        }

        for(int i = 0; i < answersButtons.Length; i++)
        {
            answersButtons[i].interactable = false;
        }
    }
}
