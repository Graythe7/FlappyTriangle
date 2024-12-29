using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    private float spawnRate = 2f;
    public float minHeight = -2f;
    public float maxHeight = 2f;

    public GameObject prefab;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipe = Instantiate(prefab, transform.position, Quaternion.identity);

        // if you don't add up the value, it would spawn in the middle of the screen 
        pipe.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

        Destroy(pipe, 5f);
    }



}
