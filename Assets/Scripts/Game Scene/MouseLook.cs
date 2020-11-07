using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float lookSensitivty = 6f, lookSmoothDamp = 0;
    [HideInInspector]
    public float yRot, xRot;
    [HideInInspector]
    public float currentY, currentX;
    [HideInInspector]
    public float yRotationV, xRotationV;

    void LateUpdate()
    {
        yRot += Input.GetAxis("Mouse X") * lookSensitivty;
        xRot += Input.GetAxis("Mouse Y") * lookSensitivty;

        currentX = Mathf.SmoothDamp(currentX, xRot, ref xRotationV, 0);
        currentY = Mathf.SmoothDamp(currentY, yRot, ref yRotationV, 0);

        xRot = Mathf.Clamp(xRot, -80, 80);

        transform.rotation = Quaternion.Euler(-currentX, currentY, 0);
    }
}
