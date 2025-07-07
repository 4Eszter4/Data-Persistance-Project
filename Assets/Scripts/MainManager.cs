using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    //public static MainManager Instance; // class member declaration; MainManager is the name of the GO i guess

    public Brick BrickPrefab;
    private int LineCount = 1;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    public GameObject NextLevelText;
    
    private bool m_Started = false;
    public int m_Points;
    
    private bool m_GameOver = false;

    public string playerName;
    public float score;

    public int levelNum = 0;

    public List<Brick> brickInstances;

    // Start is called before the first frame update
    void Start()
    {
        levelNum = MenuManager.Instance.level;
        // read the previous level score and shows
        if (MenuManager.Instance.level > 0)
        {
            m_Points = (int)MenuManager.Instance.score;
            AddPoint(0);
        }
    
        levels();

    }

    private void Update()
    {
        brickInstances.RemoveAll(b => b == null);
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                GameOver();
                m_Points = 0;
                MenuManager.Instance.score = 0;
            }
        }
        else if (brickInstances.Count == 0)
        {
            // Debug.Log("No more bricks in the scene... :)");
            // MenuManager.Instance.SaveInfo();
            NextLevelText.SetActive(true);
            Ball.gameObject.SetActive(false);

            //SceneManager.LoadScene("main2");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                levelNum += 1;
                MenuManager.Instance.level = levelNum;
                //MenuManager.Instance.SaveInfo();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        MenuManager.Instance.score = m_Points;
        MenuManager.Instance.BestScore();
        
    }

    public void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        MenuManager.Instance.level = 0;
        MenuManager.Instance.SaveInfo();
    }

    private void levels()
    {
        if (levelNum == 0)
        {
            LineCount = 6;
            const float step = 0.6f;
            int perLine = Mathf.FloorToInt(4.0f / step);
            
            int[] pointCountArray = new [] {1,1,2,2,5,5};

            brickInstances = new List<Brick>();
            
            for (int i = 0; i < LineCount; ++i)
            {
                for (int x = 0; x < perLine; ++x)
                {
                    Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                    var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                    brick.PointValue = pointCountArray[i];
                    brick.onDestroyed.AddListener(AddPoint);
                    brickInstances.Add(brick); // Track the instance
                }
            }
        }
        else if (levelNum == 1)
        {
            LineCount = 6;
            const float step = 0.6f;
            float baseWidth = 4.0f;

            int[] pointCountArray = new [] {1,1,2,2,5,5};

            brickInstances = new List<Brick>();

            for (int i = 0; i < LineCount; ++i)
            {
                // Decrease brick count each row (top has more, bottom has fewer)
                int bricksInRow = Mathf.FloorToInt(baseWidth / step) - i;

                // Center the row by calculating offset
                float rowWidth = bricksInRow * step;
                float xOffset = -rowWidth / 2.0f + step / 2.0f;

                for (int x = 0; x < bricksInRow; ++x)
                {
                    Vector3 position = new Vector3(xOffset + step * x, 2.5f + i * 0.3f, 0);
                    var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                    brick.PointValue = pointCountArray[i];
                    brick.onDestroyed.AddListener(AddPoint);
                    brickInstances.Add(brick);
                }
            }
        }
        // default
        else
        {
        LineCount = 6;
            const float step = 0.6f;
            int perLine = Mathf.FloorToInt(4.0f / step);
            
            int[] pointCountArray = new [] {1,1,2,2,5,5};

            brickInstances = new List<Brick>();
            
            for (int i = 0; i < LineCount; ++i)
            {
                for (int x = 0; x < perLine; ++x)
                {
                    Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                    var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                    brick.PointValue = pointCountArray[i];
                    brick.onDestroyed.AddListener(AddPoint);
                    brickInstances.Add(brick); // Track the instance
                }
            }
        }
    }
}
