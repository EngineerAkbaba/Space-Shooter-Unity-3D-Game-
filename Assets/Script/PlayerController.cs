using UnityEngine;
using System.Collections;

[System.Serializable] //For child class to seem on the unity editor
public class Boundary //Child class for constraits of the game play area
{
    //The constraits that the player will moves within
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed; //The speed of the player
    private Rigidbody rb; //Physics rules for the player
    public float tilt; //Gradient of the player when it moves
    public Boundary boundary; //The object of the "Boundary" class

    public GameObject shot; //Game object for bolt located in Assets->Prefabs
    public Transform shotSpawn; //Transform components for bolt game object
    public float fireRate; //Shooting rate
    private float nextFire;

    //This function is called when the current scene starts to operate
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Get the physics components of player
    }

    //Create shot
    void Update()
    {
        //Get input from the user to shoot
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; //Assign next shot
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //Create next shot
            GetComponent<AudioSource>().Play(); //Play the "weapon_player" audio source
        }
    }

    //Movements of the player
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //x direction of movement
        float moveVertical = Input.GetAxis("Vertical"); //y direction of movement

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //Vector3 gets x, y and z components
        rb.velocity = movement * speed; //Add velocity to the player according to physics rules

        //Define the constraits of the play area for the player
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), //This clamps x position between xMin and xMax
            0.0f, //Player does NOT move by y direction
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax) //This clamps z position between zMin and zMax
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * (tilt)); //Rotate the player by tilt value
    }
}