using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public GameObject[] spawnableObjects;
    public float minX, maxX, minY, maxY;
    public int xSize = 20, ySize = 20, ammoCount;

    private void Start()
    {
        ammoCount = Random.Range(1, 6);
        minX = transform.position.x - xSize / 2;
        maxX = transform.position.x + xSize / 2;
        minY = transform.position.y - ySize / 2;
        maxY = transform.position.y + ySize / 2;

        for(int i = 0; i < ammoCount ; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Length)], spawnPos, Quaternion.identity);
        }
    }
}
