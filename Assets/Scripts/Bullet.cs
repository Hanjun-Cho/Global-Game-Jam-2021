using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(0, 50)]
    public float moveSpeed = 20;

    private void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);   
    }
}
