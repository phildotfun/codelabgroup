using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [Header("Asteroids")]
    [SerializeField] GameObject largeAsteroid;
    [SerializeField] GameObject mediumAsteroid;
    [SerializeField] GameObject smallAsteroid;

    [Header("Asteroid Timer")]
    [SerializeField] float asteroidTimer = 3f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //repreat generate asteroid function every X seconds;
        InvokeRepeating("GenerateAsteroid", 0f, asteroidTimer);
    }

    //Check how many asteroids are in game
    //If it's less than 10, GenerateAsteroid
    bool AsteroidChecker()
    {
        if (GameObject.FindGameObjectsWithTag("Asteroid").Length >= 10)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //Set health for Asteroid
    int SetAsteroidHealth()
    {
        int asteroidHealth = Random.Range(0, 4);
        return asteroidHealth;
    }

    //Generate random starting position for instatiated asteroid
    Vector2 GenerateNewPosition()
    {
        float camWorldSizeY = Camera.main.orthographicSize;
        float camWorldSizeX = Camera.main.orthographicSize * Camera.main.aspect;

        float randX = Random.Range(-camWorldSizeY, camWorldSizeY);
        float randY = Random.Range(-camWorldSizeY, camWorldSizeY);
        return new Vector2(randX, randY);
    }

    //set random rotation
    Quaternion SetRandomRotation()
    {
        float randomRot = Random.Range(0f, 360f);
        Quaternion asteroidRot = Quaternion.Euler(0, 0, randomRot);
        return asteroidRot;
    }

    //Generate asteroid based on SetAsteroidHealth randomizer
    void GenerateAsteroid()
    {
        if (AsteroidChecker())
    {
            if (SetAsteroidHealth() == 3)
            {
                GameObject.Instantiate(largeAsteroid);
                largeAsteroid.transform.position = GenerateNewPosition();
                largeAsteroid.transform.rotation = SetRandomRotation();
            }
            else if (SetAsteroidHealth() == 2)
            {
                GameObject.Instantiate(mediumAsteroid);
                mediumAsteroid.transform.position = GenerateNewPosition();
                mediumAsteroid.transform.rotation = SetRandomRotation();
            }
            else if (SetAsteroidHealth() == 1)
            {
                GameObject.Instantiate(smallAsteroid);
                smallAsteroid.transform.position = GenerateNewPosition();
                smallAsteroid.transform.rotation = SetRandomRotation();
            }
            else
            {
            }
        }
    }
}

