using Mono.Cecil;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigid;
    bool jumpPressed;

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
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }
    void FixedUpdate()
    {
        if (jumpPressed)
        {
            rigid.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            jumpPressed = false;
        }
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rigid.AddForce(vec, ForceMode.Impulse);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.name == "jump block")
        {
            rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
    }
}
