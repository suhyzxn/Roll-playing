using Mono.Cecil;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigid;
    bool jumpPressed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !jumpPressed)
        {
            Jump();
        }
    }
    void FixedUpdate()
    {
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rigid.AddForce(vec * 25f, ForceMode.Force);
    }

    void Jump()
    {
        Vector3 v = rigid.linearVelocity;
        v.y = 15f;
        rigid.linearVelocity = v;
        jumpPressed = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpPressed = false;
        }
        if (collision.gameObject.CompareTag("JumpBlock"))
        {
            Vector3 v = rigid.linearVelocity;
            v.y = 30f;
            rigid.linearVelocity = v;
        }
    }
}
