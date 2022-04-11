using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script should be attached to the emmiters
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static float score;

    //private AsteroidBehavior asteroidBehavior;

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
        
    



}
