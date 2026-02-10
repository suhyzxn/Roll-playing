using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigid;
    bool jumpPressed = false;
    MoveDirection MoveDir;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        MoveDir = FindFirstObjectByType<MoveDirection>();
    }

    void isPlaying()
    {
        GameManager.instance.gameState = GameState.playing;
        rigid.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !jumpPressed)
        {
            Jump();
        }

        if (GameManager.instance.gameState == GameState.Dead)
        {
            transform.rotation = quaternion.Euler(0,0,0);
            rigid.isKinematic = true;
            
            if (transform.position.z <= 250)
            {
                transform.position = new Vector3(-38.86f, 125f, 5.77f);
                isPlaying();
            }
            else
            {
                transform.position = new Vector3(-38.86f, 160f, 250f);
                isPlaying();
            }
        }
    }
    void FixedUpdate()
    {
        rigid.AddForce(MoveDir.dir * 25f, ForceMode.Acceleration);
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
        else if (collision.gameObject.CompareTag("JumpBlock"))
        {
            Vector3 v = rigid.linearVelocity;
            v.y = 30f;
            rigid.linearVelocity = v;
        }
    }
}
