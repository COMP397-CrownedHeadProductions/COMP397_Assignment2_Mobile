using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File: CameraController.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 02-14-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 *                   Pre-Alpha - 2021.02.14
 * - Basic camera movement for third-person character
 * 
 *                       Alpha - 2021-03-08
 * - Updated camera rotation
 * 
 *                        Beta - 2021-03-21
 * - Added function for player camera rotation for mobile application (Right joystick)
 * 
 */

public class CameraController : MonoBehaviour
{
    public Joystick joystick;
    public Transform player;
    public Vector3 distance;
    public bool offSetValues;
    public float mouseSensitivity;
    public float controllerSensitivity;
    float xRotation = 0f;
    public Transform pivot;

    public bool invertYAxis;

    //Variables to set max and minimum vertical camera angle
    public float maxCameraAngle;
    public float minCameraAngle;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //distance = player.position - transform.position;
        if (!offSetValues)
        {
            distance = player.position - transform.position;
        }
        
        pivot.transform.position = player.transform.position;
        //pivot.transform.parent = player.transform;
        pivot.transform.parent = null;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        #region Mouse Camera Control    
        pivot.transform.position = player.transform.position;
        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseX = joystick.Horizontal * mouseSensitivity;
        pivot.Rotate(0, mouseX, 0);

        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        float mouseY = joystick.Vertical * mouseSensitivity;
        //Invert Y-axis function
        if (invertYAxis)
            {
                pivot.Rotate(mouseY, 0, 0);
            }
            else
            {
                pivot.Rotate(-mouseY, 0, 0);
            }
            #endregion
        
        #region Controller Camera Controller
        float controllerX = Input.GetAxis("RightJoyStickHorizontal") * controllerSensitivity * Time.deltaTime;
        float controllerY = Input.GetAxis("RightJoyStickVertical") * controllerSensitivity * Time.deltaTime;

        xRotation -= controllerY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * controllerX);

        if (invertYAxis)
        {
            pivot.Rotate(-controllerY, 0, 0);
        }
        else
        {
            pivot.Rotate(controllerY, 0, 0);
        }
        #endregion


        //Set limit to vertical camera rotation
        if (pivot.rotation.eulerAngles.x > maxCameraAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxCameraAngle, 0, 0);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360 + minCameraAngle)
        {
            pivot.rotation = Quaternion.Euler(360f + minCameraAngle, 0, 0);
        }

        float yAngle = pivot.eulerAngles.y;
        float xAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(xAngle, yAngle, 0);
        transform.position = player.position - (rotation * distance);
        if(transform.position.y < player.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }

        transform.LookAt(player);
    }
}
