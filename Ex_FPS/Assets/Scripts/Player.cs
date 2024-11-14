using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private int maxAmmo = 30;
    private int currentAmmo = 30;
    private int remainAmmo = 180;
    
    private float moveSpeed = 5.0f;
    private float dashSpeed = 10f;
    private float jumpForce = 3.0f;

    private bool isJump = false;

    private Rigidbody rigid;
    
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private GameObject bulletObj;

    [SerializeField]
    private TextMeshProUGUI textAmmo;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
        Shoot();
        Reload();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDis = cameraTransform.rotation * new Vector3(x, 0, z);

        if (Input.GetKey("left shift"))
        {
            transform.position += new Vector3(moveDis.x, 0, moveDis.z) * dashSpeed * Time.deltaTime;
        }
        else
            transform.position += new Vector3(moveDis.x, 0, moveDis.z) * moveSpeed * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJump = true;
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo != 0)
        {
            Instantiate(bulletObj, bulletSpawnPoint.transform.position, cameraTransform.transform.rotation);
            currentAmmo--;
            textAmmo.text = $"{currentAmmo}/{remainAmmo}";
        }
    }

    void Reload()
    {
        if (Input.GetKey("r") && currentAmmo != maxAmmo)
        {
            currentAmmo = maxAmmo;
            remainAmmo -= 30;
            textAmmo.text = $"{currentAmmo}/{remainAmmo}";
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground") isJump = false;
    }
}
