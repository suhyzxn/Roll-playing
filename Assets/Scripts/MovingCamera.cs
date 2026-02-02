using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    float sensitivity = 3.0f;

    float rotationX = 0f;
    float rotationY = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX += mouseX;
        rotationY -= mouseY;
        
        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0f);    // x축 기준, y축 기준 회전
    }
}
