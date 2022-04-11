using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameManager instance;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
    }


    void Update()
    {
        if (HealthManager.health == 0)
        {
            SceneManager.LoadScene(1);
            HealthManager.health = HealthManager.heartNum;
            ScoreManager.score = 0;
        }
    }

    public void Restart()
    {
       SceneManager.LoadScene(0);
    }

}
