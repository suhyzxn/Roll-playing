using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Transform target;    // 따라갈 대상 (공)
    Vector3 offset = new Vector3(0, 10f, -25f);      // 카메라와 공 사이 거리

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Start()
    {
        //transform.LookAt(target);
    }

    void LateUpdate()
    {
        transform.position = target.position + transform.rotation * offset;
    }
}
