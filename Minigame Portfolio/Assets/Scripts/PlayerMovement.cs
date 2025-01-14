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
    private GameObject[] lifeImg;
    [SerializeField]
    private GameObject panel_GameOver;

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
        Die();
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

    public void Die()
    {
        if (lifeCount >= 3)
        {
            Destroy(gameObject);
            lifeCount = 0;
            panel_GameOver.SetActive(true);
            Time.timeScale = 0;
            // 게임 오버 처리
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            lifeImg[lifeCount].SetActive(false);
            lifeCount++;
        }
    }
}
