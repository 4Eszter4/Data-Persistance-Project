using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public float newBest;
    public string newName;
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;
    public TextMeshProUGUI player3;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;

    private void Start()
    {
        if (MenuManager.Instance != null)
        {
            MenuManager.Instance.LoadInfo();
            newBest = MenuManager.Instance.score;
            newName = MenuManager.Instance.playerName;
            player1.text = MenuManager.Instance.bestPlayer1;
            player2.text = MenuManager.Instance.bestPlayer2;
            player3.text = MenuManager.Instance.bestPlayer3;
            score1.text = MenuManager.Instance.bestScore1;
            score2.text = MenuManager.Instance.bestScore2;
            score3.text = MenuManager.Instance.bestScore3;
            Debug.Log(newBest);
            if (!string.IsNullOrEmpty(score3.text) && newBest > float.Parse(score3.text))
            {
                score3.text = newBest + "";
                player3.text = newName;
            }
            if (!string.IsNullOrEmpty(score2.text) && newBest > float.Parse(score2.text))
            {
                player3.text = player2.text;
                score3.text = score2.text;
                score2.text = newBest + "";
                player2.text = newName;
            }
            if (!string.IsNullOrEmpty(score1.text) && newBest > float.Parse(score1.text))
            {
                player3.text = player2.text;
                score3.text = score2.text;
                player2.text = player1.text;
                score2.text = score1.text;
                score1.text = newBest + "";
                player1.text = newName;
            }
            if (string.IsNullOrEmpty(score1.text))
            {
                score1.text = newBest + "";
                player1.text = newName;
            }
            if (string.IsNullOrEmpty(score2.text) && !string.IsNullOrEmpty(score1.text) && newBest < float.Parse(score1.text))
            {
                score2.text = newBest + "";
                player2.text = newName;
            }
            if (string.IsNullOrEmpty(score3.text) && !string.IsNullOrEmpty(score2.text) && newBest < float.Parse(score2.text))
            {
                score2.text = newBest + "";
                player2.text = newName;
            }
            MenuManager.Instance.bestPlayer1 = player1.text;
            MenuManager.Instance.bestPlayer2 = player2.text;
            MenuManager.Instance.bestPlayer3 = player3.text;
            MenuManager.Instance.bestScore1 = score1.text;
            MenuManager.Instance.bestScore2 = score2.text;
            MenuManager.Instance.bestScore3 = score3.text;
            MenuManager.Instance.SaveInfo();
        }
        MenuManager.Instance.bestPlayer1 = player1.text;
        MenuManager.Instance.bestPlayer2 = player2.text;
        MenuManager.Instance.bestPlayer3 = player3.text;
        MenuManager.Instance.bestScore1 = score1.text;
        MenuManager.Instance.bestScore2 = score2.text;
        MenuManager.Instance.bestScore3 = score3.text;
        MenuManager.Instance.SaveInfo();
    }
}
