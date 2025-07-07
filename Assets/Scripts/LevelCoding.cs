using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LevelCoding : MonoBehaviour
{

    public Brick BrickPrefab;
    public int LineCount = 6;
    public List<Brick> brickInstances;
    public MainManager MainManager;

    // Start is called before the first frame update
    void Start()
    {
        MainManager = GetComponent<MainManager>();
    }

    public void Level()
    {
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
                brick.onDestroyed.AddListener(MainManager.AddPoint);
                brickInstances.Add(brick); // Track the instance
            }
        }
    }

}