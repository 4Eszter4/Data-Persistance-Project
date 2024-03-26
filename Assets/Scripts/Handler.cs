using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Handler : MonoBehaviour
{
    //public  nameTextObject;
    public string nameText;
    public Text nameAndScore;
    public float scoreValue;
    private void Update()
    {
        if (MenuManager.Instance != null)
        {
            //Set name and score values;
            nameText = MenuManager.Instance.playerName;
            scoreValue = MenuManager.Instance.score;

            nameAndScore.text = "Best Score : " + nameText + ": " + scoreValue;
        }
    }
    public void ExitGameButton()
    {
        //Save the color
        MenuManager.Instance.BestScore();
        //Save the color
        MenuManager.Instance.SaveInfo();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #endif
        // if only the built app
        Application.Quit();
    }
    public void HighScoreButton()
    {
        SceneManager.LoadScene("HighScore");
    }
}
