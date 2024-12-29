using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public float speed = 5f;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        spriteRenderer.color = GetRandomColor();

    }

    private Color GetRandomColor()
    {
       
        return new Color(
            Random.value, // Red
            Random.value, // Green
            Random.value  // Blue
        );
    }
}
