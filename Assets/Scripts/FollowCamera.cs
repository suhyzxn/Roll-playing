using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;    // 따라갈 대상 (공)
    public Vector3 offset;      // 카메라와 공 사이 거리

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
