using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunObject : MonoBehaviour
{
    public Gun gun;
    public bool canEnter = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (canEnter)
            {
                collision.GetComponent<Shooting>().pickUpGun(gun);
                Destroy(gameObject);
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
