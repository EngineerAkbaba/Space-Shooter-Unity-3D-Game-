using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion; //There will be explosion when any game object destroys
    public GameObject playerExplosion; //When the player is destroyed
    public int scoreValue; //The value that is added to score when the player kill an asteroid
    private GameController gameController = new GameController(); //Instance of GameController class

    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); //This will hold GameController script
        if (gameControllerObject != null) //gameControllerObject has been found
        {
            gameController = gameControllerObject.GetComponent<GameController>(); //Assign gameController script 
        }
        if (gameControllerObject == null) //gameControllerObject has NOT been found
        {
            Debug.Log("Can NOT found Game Controller script");
        }
    }

    //Destroy asteroit and/or player
    void OnTriggerEnter(Collider other)
    {
        //Check whether the asteroid crashed with the boundary
        //(The asteroid is already inside of the boundary)
        if (other.tag == "Boundary")
        {
            return; //Do NOT destroy anything
        }
        Instantiate(explosion, transform.position, transform.rotation); //Create asteroid explosion

        //If the player crashed with the asteroid
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation); //Create player explosion
            gameController.GameOver(); //Call GameOver function of GameController class to end the game
        }
        gameController.AddScore(scoreValue); //Send the scoreValue to AddScore function of GameController class to calculate the score
        Destroy(other.gameObject); //Destroy the shot which crashed with asteroid
        Destroy(gameObject); //Destroy asteroid when any shot crashed with it
    }
}
