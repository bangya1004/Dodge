using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float moveSpeed = 0.025f;

    void Awake()
    {

    }

    void Update()
    {
        Move();

        Destroy(gameObject, 2.0f);
    }

    void Move()
    {
        transform.Translate(Vector3.forward * moveSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
