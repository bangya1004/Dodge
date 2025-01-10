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
        
        if (Input.GetMouseButtonDown(0) && playerSpriteRenderer.flipX)
        {           
            playerSpriteRenderer.flipX = false;
        }
        else if (Input.GetMouseButtonDown(0) && !playerSpriteRenderer.flipX)
        {
            
            playerSpriteRenderer.flipX = true;
        }   
    }
}
