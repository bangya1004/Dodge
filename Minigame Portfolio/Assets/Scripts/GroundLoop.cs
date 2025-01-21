using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    private float width = 0f;
    private float speed = 5f;

    [SerializeField]
    private GameObject[] Obstacles;

    private BoxCollider2D groundCollider;

    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        width = groundCollider.size.x;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= -width)
        {
            RePosition();
        }
    }

    private void RePosition()
    {
        Vector2 offset = new Vector2(width * 3f, 0);
        transform.position = (Vector2)transform.position + offset;
        for (int i = 0; i < Obstacles.Length; i++)
        {
            if (Random.Range(0, 3) == 0) Obstacles[i].SetActive(true);
            else Obstacles[i].SetActive(false);
        }
    }
}
