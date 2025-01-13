using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;
    [SerializeField]
    private GameObject[] lifeImg;

    private BoxCollider2D playerCollider;
    private Rigidbody2D playerRigid;
    private SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimator;

    private int lifeCount = 0;

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
    }

    private void Move()
    {
        if (SceneManager.GetActiveScene().name == "Stage_Avoid")
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            lifeImg[lifeCount].SetActive(false);
            lifeCount++;
            if (lifeCount >= 3)
            {
                Destroy(gameObject);
                lifeCount = 0;
                // 게임 오버 처리
            }
        }
    }
}
