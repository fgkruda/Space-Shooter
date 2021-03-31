using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSesson : MonoBehaviour
{
    int score = 0;

    void Awake()
    {
        SetUpSingleton();
    }

       void Start()
    {
        
    }
 
    void Update()
    {
        
    }

    void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSesson>().Length;

        if(numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
