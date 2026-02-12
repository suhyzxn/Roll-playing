using UnityEngine;

public class Jelly : MonoBehaviour
{
    AudioSource JellyAudio;
    Collider col;
    Renderer render;
    float rotateSpeed = 20f;
    
    void Awake()
    {
        JellyAudio = GetComponent<AudioSource>();
        col = GetComponent<Collider>();
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
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
