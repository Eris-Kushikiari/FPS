using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 500f;

    private float _xRotation = 0f;
    private float _yRotation = 0f;

    private float _topClamp = -90f;
    private float _bottomClamp = 90f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float xMouse = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float yMouse = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _xRotation -= yMouse;

        _xRotation = Mathf.Clamp(_xRotation, _topClamp, _bottomClamp);

        _yRotation += xMouse;

        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
    }
}
