using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI WinLoseText;
    public TextMeshProUGUI SecretWord;
    public TextMeshProUGUI GuessNum;
    public Board gameBoard; 

    public Button RestartButton;

    public void Setup(int score, bool win, string secretWord)
    {
        score++;

        if (win)
        {
            WinLoseText.text = "You Win!";
            GuessNum.text = "You Guessed it in:\n" + score.ToString() + " Words!";
            SecretWord.text = "The word was:\n" + secretWord.ToUpper();
        } else
        {
            WinLoseText.text = "You Lose!";
            GuessNum.text = "Better Luck\nNext Time!";
            SecretWord.text = "The word was:\n" + secretWord.ToUpper();
        }

        gameObject.SetActive(true);
    }

    public void ResetGameBoard()
    {
        gameBoard.ClearBoard();
        gameObject.SetActive(false);
    }
}
