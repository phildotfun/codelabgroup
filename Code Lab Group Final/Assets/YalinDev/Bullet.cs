using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private ScoreManager score;

    private AsteroidBehavior asteroidBehavior;

    //Destroy After Collision
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Destroy(gameObject);
    //}


    private void Start()
    {
        score = GameObject.Find("score").GetComponent<ScoreManager>();
    }

    //Destroy when leaving border
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Walls")
        {
            Debug.Log("Has exited");
            Destroy(gameObject);

        } else if (other.tag == "Asteroid")
        {
            asteroidBehavior = other.GetComponent<AsteroidBehavior>();

            if (asteroidBehavior.randSize < 1f)
            {
                ScoreManager.score += 50;
            }
            else if (asteroidBehavior.randSize < 1.5f)
            {
                ScoreManager.score += 100;
            }
            else
            {
                ScoreManager.score += 200;
            }

            score.UpdateScore();
            Destroy(other.gameObject);
        }
    }
}
