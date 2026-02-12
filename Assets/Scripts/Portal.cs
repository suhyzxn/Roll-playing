using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ScoreManager.instance.score >= 3)
        {
            SceneManager.LoadScene("2D");
        }
    }
}
