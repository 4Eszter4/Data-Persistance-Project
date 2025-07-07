using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string playerName;
    public float score;
    public float best;
    public string bestPlayer;
    public string bestPlayer1;
    public string bestPlayer2;
    public string bestPlayer3;
    public string bestScore1;
    public string bestScore2;
    public string bestScore3;
    public int level;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        ////
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadInfo();
    }
    [System.Serializable] //it will only transform things to JSON if they are tagged as Serializable.
    class SaveData
    {
        public string playerName;
        public float score;
        public float best;
        public string bestPlayer;
        public string bestPlayer1;
        public string bestPlayer2;
        public string bestPlayer3;
        public string bestScore1;
        public string bestScore2;
        public string bestScore3;
        public int level;
    }
    public void SaveInfo()
    {
        //created a new instance of the save data and filled its class member
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.score = score;
        data.best = best;
        data.bestPlayer = bestPlayer;
        data.bestPlayer1 = bestPlayer1;
        data.bestPlayer2 = bestPlayer2;
        data.bestPlayer3 = bestPlayer3;
        data.bestScore1 = bestScore1;
        data.bestScore2 = bestScore2;
        data.bestScore3 = bestScore3;
        data.level = level;
        //ransformed that instance to JSON with JsonUtility.ToJson: 
        string json = JsonUtility.ToJson(data);
        // write a string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            score = data.score;
            best = data.best;
            bestPlayer = data.bestPlayer;
            bestPlayer1 = data.bestPlayer1;
            bestPlayer2 = data.bestPlayer2;
            bestPlayer3 = data.bestPlayer3;
            bestScore1 = data.bestScore1;
            bestScore2 = data.bestScore2;
            bestScore3 = data.bestScore3;
            level = data.level;
        }
    }
    public void BestScore()
    {
        if (best < score)
        {
            best = score;
            bestPlayer = playerName;
        }
    }
}
