using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public GameObject[] spawnableObjects;
    public GameObject[] trees;
    public List<GameObject> Objects = new List<GameObject>();
    public float minX, maxX, minY, maxY;
    public int xSize = 20, ySize = 20, itemCount, treeCount;

    private void Start()
    {
        generateChunk();
    }

    public void generateChunk()
    {
        if(Objects.Count > 0)
        {
            for(int i = 0; i < Objects.Count; i++)
            {
                Destroy(Objects[i]);
            }

            Objects.Clear();
        }

        itemCount = Random.Range(5, 15);
        treeCount = Random.Range(15, 30);
        minX = transform.position.x - xSize / 2;
        maxX = transform.position.x + xSize / 2;
        minY = transform.position.y - ySize / 2;
        maxY = transform.position.y + ySize / 2;

        for (int i = 0; i < itemCount; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Objects.Add(Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Length)], spawnPos, Quaternion.identity));
        }

        for (int i = 0; i < treeCount; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Objects.Add(Instantiate(trees[Random.Range(0, trees.Length)], spawnPos, Quaternion.identity));
        }
    }
}
