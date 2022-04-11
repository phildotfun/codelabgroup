using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [Header("Asteroids")]
    [SerializeField] GameObject asteroidPrefab;

    GameObject liveAsteroid;

    [Header("Spawner")]
    [SerializeField] GameObject spawnOne;
    [SerializeField] GameObject spawnTwo;
    [SerializeField] GameObject spawnThree;
    [SerializeField] GameObject spawnFour;

    Transform spawnerTrans;


    [Header("Asteroid Timer")]
    [SerializeField] float asteroidTimer = 2f;
    float elapsedTime;

    private Quaternion newRotation;
    Vector3 newPosition;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= asteroidTimer)
        {
            elapsedTime = 0;
            GenerateAsteroid();
        }
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

    //create a random number used to determine
    //the spawner location and rotation
    int RandomSpawnerPosition()
    {
        int randSpawnNum = Random.Range(1, 5);
        Debug.Log(randSpawnNum);
        return randSpawnNum;
    }

    float RandomAngle()
    {
        float randomRot = Random.Range(-40f, 40f);        
        return randomRot;
    }

    float randPosition()
    {
        float randomPos = Random.Range(-5f, 5f);
        return randomPos;
    }
    //Generate asteroid based on SetAsteroidHealth randomizer
    void GenerateAsteroid()
    {
        RandomSpawnerPosition();

        newPosition = new Vector3(0, 0, 0);

        if (RandomSpawnerPosition() == 1)
        {
            spawnerTrans = spawnOne.transform;
            newPosition = new Vector3(randPosition(), 0, 0);
        }
        else if (RandomSpawnerPosition() == 2)
        {
            spawnerTrans = spawnTwo.transform;
            newPosition = new Vector3(0, randPosition(), 0);
        }
        else if (RandomSpawnerPosition() == 3)
        {
            spawnerTrans = spawnThree.transform;
            newPosition = new Vector3(randPosition(), 0, 0);

        }
        else if (RandomSpawnerPosition() == 4)
        {
            spawnerTrans = spawnFour.transform;
            newPosition = new Vector3(0, randPosition(), 0);
        }


        newPosition += spawnerTrans.position;

        float zAngle = spawnerTrans.rotation.eulerAngles.z + RandomAngle();

        //instatiate new gameoject at spawner that has a new location and rotation
        Instantiate(asteroidPrefab, newPosition, Quaternion.Euler(0f,0f,zAngle));

    }
}

