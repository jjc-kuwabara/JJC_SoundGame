using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public enum SCORE_TYPE {
        PERFECT,
        GOOD,
        BAD,
        MISS,
        NUM
    }

    [SerializeField]
    int[] scoreNum = new int[(int)SCORE_TYPE.NUM];
    [SerializeField]
    GameObject[] scoreText = new GameObject[(int)SCORE_TYPE.NUM];

    private void Awake()
    {
        ClearScore();
        RefreshScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(SCORE_TYPE scoreType)
    {
        scoreNum[(int)scoreType]++;
        RefreshScore();
    }

    public void ClearScore()
    {
        for (int i = 0; i < (int)SCORE_TYPE.NUM; i++)
        {
            scoreNum[i] = 0;
        }
    }

    public void RefreshScore()
    {
        for (int i = 0; i < (int)SCORE_TYPE.NUM; i++)
        {
            scoreText[i].GetComponent<Text>().text = scoreNum[i].ToString();
        }
    }
}
