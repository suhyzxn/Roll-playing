using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Transform target;    // 따라갈 대상 (공)
    Vector3 offset;      // 카메라와 공 사이 거리

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //transform.LookAt(target);
    }

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
