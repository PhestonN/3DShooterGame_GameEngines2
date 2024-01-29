using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public float newHeight = 2.0f;
    public AudioSource Open;



    void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
        Open.Play();
    }
    
}