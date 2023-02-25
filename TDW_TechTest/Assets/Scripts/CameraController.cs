using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    public Camera cameraView;
    private float rotX = 0.0f;
    private float rotY = 0.0f;

    private void Update()
    {
       float horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;
       float verticalMovement = Input.GetAxisRaw("Vertical") * moveSpeed;
        float depthMovement = 0;

        if (Input.GetKey(KeyCode.Space))
           depthMovement = moveSpeed;
        else if (Input.GetKey(KeyCode.LeftShift))
           depthMovement = -moveSpeed;

        this.transform.Translate(horizontalMovement, depthMovement, verticalMovement);


        rotY += Input.GetAxis("Mouse X") * 5.0f;
        rotX += Input.GetAxis("Mouse Y") * 5.0f;
        rotX = Mathf.Clamp(rotX, -60.0f, 60.0f);

       // transform.localEulerAngles = new Vector3(0, rotY, 0);
       // cameraView.transform.localEulerAngles = new Vector3(-rotX, 0);
    }
}
