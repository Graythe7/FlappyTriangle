using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.8f;

    private Rigidbody2D rb;
    private Vector3 direction;
    private SpriteRenderer spriteRenderer;

    public float rotationSpeed = 5;
    public float maxRotationUp = -45f;
    public float maxRotationDown = -180f;
    public float newZ;

    public GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        transform.rotation = Quaternion.Euler(0f, 0f, -1800);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * speed;
            
        }

        // if the player not hitting the space button, it would be drag down due to gravity 
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        //calculate the rotation based on the direction of movement
        //TBH have no idea how it actually works 
        float targetZ = direction.y > 0 ? maxRotationUp : maxRotationDown;
        float newZ = Mathf.LerpAngle(transform.rotation.eulerAngles.z, targetZ, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, newZ);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
        }

        if (other.CompareTag("Score"))
        {
            gameManager.IncreaseScore();
        }

        if (other.CompareTag("Color"))
        {
            Debug.Log("ColorChanged!");

            spriteRenderer.color = GetRandomColor();
        }
    }

    private Color GetRandomColor()
    {
        Debug.Log("GetRandomColor is being called");
        // Generate a random color
        return new Color(
            Random.value, // Red
            Random.value, // Green
            Random.value  // Blue
        );
    }
}
