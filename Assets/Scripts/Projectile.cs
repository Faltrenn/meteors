using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        if(transform.position.x <= -10.5f || transform.position.x >= 10.5f || transform.position.y <= -7.5f || transform.position.y >= 7.5f) {
            Destroy(gameObject);
        }
    }
}
