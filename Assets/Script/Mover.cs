using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed; //The speed of the shot
    private Rigidbody rb; //Physics rules for the shot

    //This function is called when the current scene starts to operate
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Get the physics components of shot
        rb.velocity = transform.forward * speed; //Add velocity to the shot according to physics rules
    }
}
