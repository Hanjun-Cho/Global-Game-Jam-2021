using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(0, 50)]
    public float moveSpeed = 20;
    public GameObject deathParticles;

    private void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            Destroy(gameObject);
            Destroy(Instantiate(deathParticles, transform.position, Quaternion.identity), 2f);
            Destroy(collision.gameObject);
        }
    }
}
