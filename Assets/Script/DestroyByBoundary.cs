using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    //Control that if the shots exit from the bundary
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject); //Destroy the shots
    }
}
