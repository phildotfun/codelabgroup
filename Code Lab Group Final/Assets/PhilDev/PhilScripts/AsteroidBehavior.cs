using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{

    [SerializeField] GameObject projectile;

    float randSpeed;

    // Start is called before the first frame update
    void Start()
    {
        randSpeed = Random.Range(2f, 4f);
        gameObject.transform.localScale = RandomAsteroidSize();
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    //set random asteroid size when instatiated
    Vector3 RandomAsteroidSize()
    {
        float randSize = Random.Range(.5f, 2f);

        Vector3 asteroidSize;
        asteroidSize = new Vector3(randSize, randSize, randSize);

        return asteroidSize;
    }

    //move asteroid along right axis
    void AsteroidMovement()
    {
        transform.Translate(Vector2.right * randSpeed * Time.deltaTime);
    }

    //when asteroid leaves bounds, destory asteroid
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Walls")
        {
            Debug.Log("Has exited");
            Destroy(gameObject);

        }
    }

    //when hit by player projectile, destory asteroid
    private void OnCollisionEnter2D(Collision2D collision)
    {

        {
            Destroy(gameObject);
        }
    }


}
