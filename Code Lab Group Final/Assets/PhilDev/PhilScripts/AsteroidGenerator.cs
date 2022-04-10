using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [Header("Asteroids")]
    [SerializeField] GameObject largeAsteroid;
    [SerializeField] GameObject mediumAsteroid;
    [SerializeField] GameObject smallAsteroid;

    [Header("Spawner")]
    [SerializeField] GameObject spawnOne;
    [SerializeField] GameObject spawnTwo;
    [SerializeField] GameObject spawnThree;
    [SerializeField] GameObject spawnFour;

    [Header("Asteroid Timer")]
    [SerializeField] float asteroidTimer = 2f;
    float elapsedTime;

    private List<Vector2> spawnLocations = new List<Vector2>();
    private Quaternion newRotation;
    Vector2 newPosition;



    // Start is called before the first frame update
    void Start()
    {
        spawnLocations.Add(spawnOne.transform.position);
        spawnLocations.Add(spawnTwo.transform.position);
        spawnLocations.Add(spawnThree.transform.position);
        spawnLocations.Add(spawnFour.transform.position);
    }

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

    //Set health for Asteroid
    int SetAsteroidHealth()
    {
        int asteroidHealth = Random.Range(1,4);
        return asteroidHealth;
    }

    //create a random number used to determine
    //the spawner location and rotation
    int RandomSpawnerProperty()
    {
        int randSpawnNum = Random.Range(0, 4);
        return randSpawnNum;
    }

    float RandomRotation()
    {
        float randomRot = Random.Range(-10f, 10f);
        return randomRot;
    }

    //Generate random to set spawning point
    Vector2 GenerateNewPosition(int randSpawnNum)
    {
        return  newPosition = spawnLocations[randSpawnNum];
    }

    //set random rotation
    Quaternion SetRandomRotation(int randSpawnNum)
    {

        if (randSpawnNum == 1)
        {
            newRotation = Quaternion.Euler(0, 0, spawnOne.transform.rotation.eulerAngles.z);
        }
        else if (randSpawnNum == 2)
        {
            newRotation = Quaternion.Euler(0, 0, spawnTwo.transform.rotation.eulerAngles.z);
        }
        else if (randSpawnNum == 3)
        {
            newRotation = Quaternion.Euler(0, 0, spawnThree.transform.rotation.eulerAngles.z);
        }
        else if (randSpawnNum == 4)
        {
            newRotation = Quaternion.Euler(0, 0, spawnFour.transform.rotation.eulerAngles.z);
        }
        return newRotation;
    }

    //Generate asteroid based on SetAsteroidHealth randomizer
    void GenerateAsteroid()
    {

        if (AsteroidChecker())
    {
            if (SetAsteroidHealth() == 3)
            {
                GameObject.Instantiate(largeAsteroid, GenerateNewPosition(RandomSpawnerProperty()), SetRandomRotation(RandomSpawnerProperty()));

            }
            else if (SetAsteroidHealth() == 2)
            {
                GameObject.Instantiate(mediumAsteroid, GenerateNewPosition(RandomSpawnerProperty()), SetRandomRotation(RandomSpawnerProperty()));
            }
            else if (SetAsteroidHealth() == 1)
            {
                GameObject.Instantiate(smallAsteroid, GenerateNewPosition(RandomSpawnerProperty()), SetRandomRotation(RandomSpawnerProperty()));
            }
            else
            {
            }
        }
    }
}

