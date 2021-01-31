using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGen : MonoBehaviour
{
    public GameObject ChunkPrefab;
    public Chunk[] chunks;

    void Start()
    {
        chunks = new Chunk[]
        {
            Instantiate(ChunkPrefab, Vector2.zero, Quaternion.identity).GetComponent<Chunk>(),
            Instantiate(ChunkPrefab, new Vector2(20, 0), Quaternion.identity).GetComponent<Chunk>(),
            Instantiate(ChunkPrefab, new Vector2(-20, 0), Quaternion.identity).GetComponent<Chunk>(),
            Instantiate(ChunkPrefab, new Vector2(0, 20), Quaternion.identity).GetComponent<Chunk>(),
            Instantiate(ChunkPrefab, new Vector2(0, -20), Quaternion.identity).GetComponent<Chunk>(),
            Instantiate(ChunkPrefab, new Vector2(20, 20), Quaternion.identity).GetComponent<Chunk>(),
            Instantiate(ChunkPrefab, new Vector2(20, -20), Quaternion.identity).GetComponent<Chunk>(),
            Instantiate(ChunkPrefab, new Vector2(-20, 20), Quaternion.identity).GetComponent<Chunk>(),
            Instantiate(ChunkPrefab, new Vector2(-20, -20), Quaternion.identity).GetComponent<Chunk>()
        };
    }

    private void Update()
    {
        for(int i = 0; i < chunks.Length; i++)
        {
            if(Mathf.Abs(chunks[i].transform.position.x - PlayerController.Position.x) > 30)
            {
                if(chunks[i].transform.position.x - PlayerController.Position.x < 0)
                {
                    chunks[i].transform.position = new Vector2(chunks[i].transform.position.x + 60, chunks[i].transform.position.y);
                    chunks[i].generateChunk();
                }
                else if(chunks[i].transform.position.x - PlayerController.Position.x > 0)
                {
                    chunks[i].transform.position = new Vector2(chunks[i].transform.position.x - 60, chunks[i].transform.position.y);
                    chunks[i].generateChunk();
                }
            }

            if(Mathf.Abs(chunks[i].transform.position.y - PlayerController.Position.y) > 30)
            {
                if(chunks[i].transform.position.y - PlayerController.Position.y < 0)
                {
                    chunks[i].transform.position = new Vector2(chunks[i].transform.position.x, chunks[i].transform.position.y + 60);
                    chunks[i].generateChunk();
                }
                else if(chunks[i].transform.position.y - PlayerController.Position.y > 0)
                {
                    chunks[i].transform.position = new Vector2(chunks[i].transform.position.x, chunks[i].transform.position.y - 60);
                    chunks[i].generateChunk();
                }
            }
        }
    }
}
