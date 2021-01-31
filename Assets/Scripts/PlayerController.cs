using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Vector2 Position;
    [Range(0, 50)] public float playerSpeed;
    public Transform firePort, armTransform;
    public GameObject bulletPrefab, muzzleFlash;

    private void Update()
    {
        movePlayer();
    }

    public void shoot(GameObject gunBarrel, Gun curGun)
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePort.transform.position, armTransform.rotation);
        Destroy(bulletObj, 20);

        gunBarrel.GetComponent<Animator>().SetBool("Fire", true);
        gunBarrel.GetComponent<Animator>().SetInteger("gun ID", curGun.gunID);

        GameObject muzzleFlashObj = Instantiate(muzzleFlash, firePort.transform.position, Quaternion.identity);
        Destroy(muzzleFlashObj, 1f);
    }

    private void movePlayer()
    {
        Vector2 moveDir = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDir.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDir.y = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDir.x = 1;
        }

        transform.Translate(moveDir * playerSpeed * Time.deltaTime);
        Position = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {
            transform.Find("Main Camera").transform.parent = null;
            Destroy(gameObject);
            print("GAME OVER");
        }
    }
}
