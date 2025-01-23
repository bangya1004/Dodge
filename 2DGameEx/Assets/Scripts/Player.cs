using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float moveSpeed = 3.0f;

    private Vector2 inputVec;
    private Rigidbody2D playerRigid;
    private SpriteRenderer playerSprite;
    private Animator playerAnim;

    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 moveVector = inputVec * moveSpeed * Time.fixedDeltaTime;
        playerRigid.MovePosition(playerRigid.position + moveVector);
    }
    private void LateUpdate()
    {
        playerAnim.SetFloat("Speed", inputVec.magnitude);
        if (inputVec.x != 0)
        {
            playerSprite.flipX = inputVec.x < 0;
        }
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
