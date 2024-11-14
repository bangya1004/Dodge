using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float rotateSpeedX = 3.0f;
    private float rotateSpeedY = 5.0f;

    private float eulerAngleX;
    private float eulerAngleY;

    private float limitMinX = -50;
    private float limitMaxX = 30;


    void Awake()
    {

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        RotateTo(mouseX, mouseY);
    }

    void RotateTo(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotateSpeedX;
        eulerAngleX -= mouseY * rotateSpeedY;

        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
