using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;
    public int scoreValue;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Canno find 'Game Controller' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        { 
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            if (other.tag == "Player")
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
