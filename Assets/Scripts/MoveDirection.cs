using UnityEngine;

public class MoveDirection : MonoBehaviour
{
    public Vector3 dir {get; private set;}

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        dir = forward * v + right * h;
    }
}
