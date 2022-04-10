using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    void AsteroidMovement()
    {
        float randSpeed = Random.Range(2f, 4f);
        transform.Translate(Vector2.right * randSpeed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Walls")
        {
            Debug.Log("Has exited");
            Destroy(gameObject);

        }
    }

    //when hit by player projectile, destory object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == projectile)
        {
            Destroy(gameObject);
        }
    }


}
