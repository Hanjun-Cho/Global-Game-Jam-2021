using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunObject : MonoBehaviour
{
    public Gun gun;
    public bool canEnter = true, spawnedStart = true;
    public int currentAmmoCount;

    private void Start()
    {
        if (spawnedStart)
        {
            gun = FindObjectOfType<GameManager>().guns[Random.Range(0, FindObjectOfType<GameManager>().guns.Length)];
            currentAmmoCount = Random.Range(0, 13);
        }
    }

    private void Update()
    {
        if(gun != null)
        {
            GetComponent<SpriteRenderer>().sprite = gun.droppedSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (canEnter)
            {
                if(collision.GetComponent<Shooting>().currentGun == null)
                {
                    collision.GetComponent<Shooting>().pickUpGun(gun, this);
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!canEnter)
            {
                canEnter = true;
            }
        }
    }
}
