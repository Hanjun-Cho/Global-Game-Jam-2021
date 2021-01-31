using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoObject : MonoBehaviour
{
    public int ammoCount;

    private void Start()
    {
        ammoCount = Random.Range(3, 13);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Shooting>().pickUpAmmo(ammoCount);
            Destroy(gameObject);
        }
    }
}
