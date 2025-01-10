using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 1.0f;

    private BoxCollider2D playerCollider;
    private Rigidbody2D playerRigid;
    private SpriteRenderer playerSpriteRenderer;

    private void Awake()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        playerRigid = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        if (x > 0 && playerSpriteRenderer.flipX)
        {           
            playerSpriteRenderer.flipX = false;
        }
        else if (x < 0 && !playerSpriteRenderer.flipX)
        {
            
            playerSpriteRenderer.flipX = true;
        }

        transform.position += new Vector3(x, 0, 0) * moveSpeed * Time.deltaTime;
    }
}
