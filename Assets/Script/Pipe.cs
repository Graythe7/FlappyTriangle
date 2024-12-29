using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 5f;
    
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; 
    }
}