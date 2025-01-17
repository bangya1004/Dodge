using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;
    [SerializeField]
    private GameManager gameManager;

    private BoxCollider2D playerCollider;
    private Rigidbody2D playerRigid;
    private SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimator;

    private bool isGrounded = false;
    private float jumpForce = 250.0f;
    private int jumpCount = 0;

    private void Awake()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        playerRigid = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        if (SceneManager.GetActiveScene().name == "Stage_Avoid" ||
            SceneManager.GetActiveScene().name == "Stage_03")
        {
            playerAnimator.SetBool("isRun", true);

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

    private void Jump()
    {
        if (SceneManager.GetActiveScene().name == "Stage_02")
        {
            playerAnimator.SetBool("isRun", true);

            if (Input.GetMouseButtonDown(0) && jumpCount < 2)
            {
                jumpCount++;

                playerRigid.velocity = Vector2.zero;
                playerRigid.AddForce(new Vector2(0, jumpForce));
            }
            else if (Input.GetMouseButtonUp(0) && playerRigid.velocity.y > 0)
            {
                playerRigid.velocity = playerRigid.velocity * 0.5f;
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            gameManager.playerCollider();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥에 닿았음을 감지하는 처리
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;
    }
}
