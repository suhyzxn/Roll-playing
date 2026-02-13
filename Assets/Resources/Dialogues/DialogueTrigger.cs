using System.Collections;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Ball ball = other.GetComponent<Ball>();

            ball.SetControl(false);

            if (ScoreManager.instance.score < 3)
            {
                DialogueManager.Instance.PlayFromJson("Ball_dg", "need_score");
            }
            else
            {
                DialogueManager.Instance.PlayFromJson("Ball_dg", "enough_score");
            }
            StartCoroutine(WaitForDialogue(ball)); 
        }
    }

    IEnumerator WaitForDialogue(Ball ball)
    {
        yield return new WaitUntil(()=> !DialogueManager.Instance.Texting);
        ball.SetControl(true);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
