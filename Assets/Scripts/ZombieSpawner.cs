using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public float spawnRadius = 100;
    public GameObject[] enemies;

    public float time = 10;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        Vector2 spawnPos = PlayerController.Position;

        spawnPos += UnityEngine.Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnEnemy());
    }
}