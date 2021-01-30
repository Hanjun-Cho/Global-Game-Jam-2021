using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 50)] public float playerSpeed;
    public Transform firePort, armTransform;
    public GameObject bulletPrefab;

    private void Update()
    {
        movePlayer();
    }

    public void shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePort.transform.position, armTransform.rotation);
        Destroy(bulletObj, 20);
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
    }
}
