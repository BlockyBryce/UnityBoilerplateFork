using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class MathGameController : MonoBehaviour
{
    [Header("Math Question")]
    public TMP_Text questionText;
    public TMP_InputField answerInput;
    public TMP_Text feedbackText;
    public TMP_Text scoreText;

    [Header("Buttons")]
    public Button checkAnswerButton;

    [Header("Battery Settings")]
    public int batteryGain = 10;
    public int batteryLoss = -10;

    private int correctAnswer;
    private int correctCount = 0;
    private bool waitingForNextQuestion = false;
    private bool gameOver = false;

    private void Start()
    {
        // Connect the Check Answer button.
        checkAnswerButton.onClick.AddListener(CheckAnswer);

        // Show the starting score.
        UpdateScore();

        // Generate the first question.
        GenerateQuestion();
    }

    private void OnDestroy()
    {
        if (checkAnswerButton != null)
        {
            checkAnswerButton.onClick.RemoveListener(CheckAnswer);
        }
    }

    // Generate a random math question.
    private void GenerateQuestion()
    {
        int number1;
        int number2;
        int operation = Random.Range(0, 4);
        string symbol;

        switch (operation)
        {
            case 0:
                // Addition
                number1 = Random.Range(1, 51);
                number2 = Random.Range(1, 51);

                correctAnswer = number1 + number2;
                symbol = "+";
                break;

            case 1:
                // Subtraction without negative answers
                number1 = Random.Range(1, 101);
                number2 = Random.Range(1, number1 + 1);

                correctAnswer = number1 - number2;
                symbol = "-";
                break;

            case 2:
                // Multiplication
                number1 = Random.Range(2, 13);
                number2 = Random.Range(2, 13);

                correctAnswer = number1 * number2;
                symbol = "×";
                break;

            default:
                // Division with whole-number answers
                number2 = Random.Range(2, 13);
                correctAnswer = Random.Range(1, 13);
                number1 = number2 * correctAnswer;

                symbol = "÷";
                break;
        }

        questionText.text =
            number1 + " " + symbol + " " + number2 + " = ?";

        answerInput.text = "";
        feedbackText.text = "Enter your answer.";

        waitingForNextQuestion = false;
        checkAnswerButton.interactable = true;
        answerInput.interactable = true;
    }

    // Check the number entered by the player.
    public void CheckAnswer()
    {
        var batteryScript = FindAnyObjectByType<BatteryDisplay>();
        if (gameOver || waitingForNextQuestion)
        {
            return;
        }

        string playerInput = answerInput.text.Trim();

        int playerAnswer;

        if (!int.TryParse(playerInput, out playerAnswer))
        {
            feedbackText.text = "Please enter a whole number.";
            return;
        }

        waitingForNextQuestion = true;

        checkAnswerButton.interactable = false;
        answerInput.interactable = false;

        if (playerAnswer == correctAnswer)
        {
            correctCount++;

            batteryScript.ChangeBattery(batteryGain);

            feedbackText.text = "Correct! Battery increased.";
        }
        else
        {
            batteryScript.ChangeBattery(batteryLoss);

            feedbackText.text =
                "Incorrect! The answer was " + correctAnswer + ".";
        }

        UpdateScore();

        // Wait briefly before displaying another question.
        StartCoroutine(NextQuestion());
    }

    private IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(1.5f);

        GenerateQuestion();
    }

    // Update the correct-answer counter.
    private void UpdateScore()
    {
        scoreText.text = "Correct: " + correctCount;
    }

    // Restart the math challenge.
    public void RestartGame()
    {
        StopAllCoroutines();

        gameOver = false;
        waitingForNextQuestion = false;
        correctCount = 0;

        // Keep the current battery level.
        // The player must earn battery by answering correctly.

        UpdateScore();
        GenerateQuestion();
    }
}