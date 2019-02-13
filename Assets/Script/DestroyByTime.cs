using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
    public float lifetime; //Lifetime of explosions
    void Start()
    {
        Destroy(gameObject, lifetime); //Destroy explosions some time later (as long as lifetime)
    }
}
