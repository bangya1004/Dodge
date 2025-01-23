using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float moveSpeed = 3.0f;

    private Vector2 inputVec;
    private Rigidbody2D playerRigid;

    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();    
    }

    private void FixedUpdate()
    {
        Vector2 moveVector = inputVec * moveSpeed * Time.fixedDeltaTime;
        playerRigid.MovePosition(playerRigid.position + moveVector);
    }
    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
