using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
public class MenuCanvas : MonoBehaviour
{
    public new TMP_InputField name;
    public Text title;
    private void Start()
    {
        name.text = MenuManager.Instance.bestPlayer;
        title.text = "Best score: " + MenuManager.Instance.bestPlayer + " score: " + MenuManager.Instance.best;
    }
    public void StartButtonFunction()
    {
        MenuManager.Instance.playerName = name.text;
        //MenuManager.Instance.score = 1;
        SceneManager.LoadScene("main");
    }
    public void HighScoreButtonFunction()
    {
        SceneManager.LoadScene("HighScore");
    }
    public void ExitGame()
    {
        //Save the color
        MenuManager.Instance.BestScore();
        //refresh HighScore scene
        MenuManager.Instance.SaveInfo();
        //if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        // if only the built app
        Application.Quit();
    }
}
