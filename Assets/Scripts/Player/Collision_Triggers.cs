using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_Triggers : MonoBehaviour
{
    [SerializeField]
    private Transform BOOM;

    // Obstacle Collision Detection with BOOM Simple Particle Effect
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obs")
        {
            Destroy(gameObject);
            Instantiate(BOOM, transform.position, BOOM.rotation);
            SceneManager.LoadScene("Done");
        }


    }

    //Triggering Coin and Capsule 
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "coin")
        {
            //Play Sound
            GameMaster.instance.PlayCollectableSound();
            Destroy(other.gameObject);
            GameMaster.coinTotal++;
        }

        //Nothing to be done 
        if (other.gameObject.tag == "Capsule")
        {
            Destroy(other.gameObject);
        }
    }

    //When a Single platform ends it destroy itself then Instantiate new Platform
    void OnTriggerExit(Collider target)
    {
        if (target.name == "OUT")
        {
            Destroy(target.gameObject.transform.parent.gameObject, 1);
            GameMaster.instance.CreateTiles();
        }
    }
}
