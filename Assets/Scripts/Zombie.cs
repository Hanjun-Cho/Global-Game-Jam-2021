using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Range(0, 15)]
    public float moveSpeed = 5;
    public float offset = 90;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerController.Position, moveSpeed * Time.deltaTime);
        rotateZombie();
    }

    private void rotateZombie()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 playerPositionOnScreen = PlayerController.Position;
        float angle = AngleBetweenTwoPoints(positionOnScreen, playerPositionOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + offset));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
