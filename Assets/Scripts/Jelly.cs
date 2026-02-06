using UnityEngine;

public class Jelly : MonoBehaviour
{
    AudioSource JellyAudio;
    Collider col;
    Renderer render;
    
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
            col.enabled = false;
            render.enabled = false;
        }
    }
}
