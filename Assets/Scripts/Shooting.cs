using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public Gun currentGun;
    public GameObject gunBarrel, gunDropped;
    public GameObject pistolaHands, idleHands;
    private float curFireRate = 0;
    public TextMeshProUGUI AmmoCounter;
    public GameObject reloadingText;

    public int totalAmmoCount = 0, currentAmmoCount = 0;
    public bool reloading = false;

    private void Update()
    {
        AmmoCounter.text = currentAmmoCount.ToString() + "/" + totalAmmoCount.ToString();

        if (currentGun != null && gunBarrel.activeSelf)
        {
            if (!reloading && currentAmmoCount > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    curFireRate = currentGun.fireRate;
                }

                if (Input.GetMouseButton(0))
                {
                    if (curFireRate >= currentGun.fireRate)
                    {
                        if(currentAmmoCount > 0)
                        {
                            GetComponent<PlayerController>().shoot(gunBarrel, currentGun);
                            currentAmmoCount--;
                            curFireRate = 0;
                        }
                    }
                    else
                    {
                        gunBarrel.GetComponent<Animator>().SetBool("Fire", false);

                        if(gunBarrel.GetComponent<Animator>().GetBool("Fire") == false && currentGun != null)
                        {
                            curFireRate += Time.deltaTime;
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                dropGun();
            }

            if(currentGun != null)
            {
                if(currentAmmoCount <= 0 && !reloading)
                {
                    reloading = true;
                    reloadingText.GetComponent<TextMeshProUGUI>().text = "RELOADING...";
                    reloadingText.SetActive(true);
                    StartCoroutine(reload());
                }
                else if(totalAmmoCount == 0 && reloading)
                {
                    reloadingText.SetActive(true);
                    reloadingText.GetComponent<TextMeshProUGUI>().text = "OUT OF AMMO";
                }
            }
        }
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(3);
        FindObjectOfType<AudioManager>().Play("Reload");
        
        if(totalAmmoCount <= 12)
        {
            currentAmmoCount = totalAmmoCount;
            totalAmmoCount = 0;

            reloading = false;
            reloadingText.SetActive(false);
        }
        else
        {
            totalAmmoCount -= 12;
            currentAmmoCount += 12;

            reloading = false;
            reloadingText.SetActive(false);
        }
    }

    public void dropGun()
    {
        GameObject gunDrop = Instantiate(gunDropped, transform.position, Quaternion.identity);
        gunDrop.GetComponent<GunObject>().spawnedStart = false;
        gunDrop.GetComponent<SpriteRenderer>().sprite = currentGun.droppedSprite;
        gunDrop.GetComponent<GunObject>().canEnter = false;
        gunDrop.GetComponent<GunObject>().currentAmmoCount = currentAmmoCount;
        currentAmmoCount = 0;
        currentGun = null;
        gunBarrel.SetActive(false);
        StopCoroutine(reload());
        reloading = false;
        reloadingText.SetActive(false);

        idleHands.SetActive(true);
        pistolaHands.SetActive(false);
    }

    public void pickUpGun(Gun gun, GunObject gunObject)
    {
        if(currentGun != null)
        {
            dropGun();
        }

        currentGun = gun;
        currentAmmoCount = gunObject.currentAmmoCount;
        gunBarrel.SetActive(true);

        if(gun.gunID == 0)
        {
            idleHands.SetActive(false);
            pistolaHands.SetActive(true);
        }

        FindObjectOfType<AudioManager>().Play("Pickup");
    }

    public void pickUpAmmo(int ammoCount) {
        totalAmmoCount += ammoCount;
        FindObjectOfType<AudioManager>().Play("Pickup");
    }
}
