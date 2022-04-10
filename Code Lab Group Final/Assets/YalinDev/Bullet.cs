using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Destroy After Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


    //Destroy when leaving border
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Walls")
        {
            Debug.Log("Has exited");
            Destroy(gameObject);

        }
    }
}
