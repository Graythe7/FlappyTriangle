using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSpawner : MonoBehaviour
{
    public float spawnRate = 3f;
    public float spawnRange = 4;
    public GameObject colorPrefab;

    

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
        GameObject randomColor = Instantiate(colorPrefab, transform.position, Quaternion.identity);

        randomColor.transform.position += Vector3.up * Random.Range(-spawnRange, spawnRange);

        Destroy(randomColor, 5f);
    }
}
