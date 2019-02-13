using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    public float tumble; //Maximum tumble value of the asteroid

    //Start run when the current scene starts running
    void Start()
    {
        //Rotate the asteroid randomly
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}
