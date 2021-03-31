using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
   Text scoreText;
   GameSesson gameSession;
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSesson>();
        
        
    }

   
    void Update()
    {
        scoreText.text  = gameSession.GetScore().ToString();
    }
}
