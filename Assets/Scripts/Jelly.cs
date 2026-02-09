using UnityEngine;

public class Jelly : MonoBehaviour
{
    AudioSource JellyAudio;
    Collider col;
    Renderer render;
    [SerializeField]
    GameObject portal_2d;
    
    void Awake()
    {
        JellyAudio = GetComponent<AudioSource>();
        col = GetComponent<Collider>();
        render = GetComponent<Renderer>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(1);
            JellyAudio.Play();
            if (ScoreManager.instance.score >= 3)
            {
                portal_2d.SetActive(true);
            }
            col.enabled = false;
            render.enabled = false;
        }
    }
}
