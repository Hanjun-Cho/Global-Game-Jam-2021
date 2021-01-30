using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Gun currentGun;
    public GameObject gunBarrel, gunDropped;
    private float curFireRate = 0;

    private void Update()
    {
        if (currentGun != null && gunBarrel.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                curFireRate = currentGun.fireRate;
            }

            if (Input.GetMouseButton(0))
            {
                if (curFireRate >= currentGun.fireRate)
                {
                    GetComponent<PlayerController>().shoot();
                    curFireRate = 0;
                }
                else
                {
                    curFireRate += Time.deltaTime;
                }
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                print("Yoink");
                dropGun();
            }
        }
    }

    public void dropGun()
    {
        GameObject gunDrop = Instantiate(gunDropped, transform.position, Quaternion.identity);
        gunDrop.GetComponent<SpriteRenderer>().sprite = currentGun.droppedSprite;
        gunDrop.GetComponent<GunObject>().canEnter = false;
        currentGun = null;
        gunBarrel.SetActive(false);
    }

    public void pickUpGun(Gun gun)
    {
        currentGun = gun;
        gunBarrel.SetActive(true);
    }
}
