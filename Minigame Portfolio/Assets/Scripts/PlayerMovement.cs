using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 1.0f;

    private BoxCollider2D playerCollider;
    private Rigidbody2D playerRigid;

    private void Awake()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        playerRigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {

    }
}
