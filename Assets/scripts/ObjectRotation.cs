using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float rotationSpeed = 200f; 

    void Update()
    {
         
        transform.Rotate(0f,0f , rotationSpeed * Time.deltaTime);
    }
}