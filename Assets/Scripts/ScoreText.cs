using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    void Start()
    {
        ScoreManager.instance.OnScoreChanged += ScoreUpdate;
        ScoreUpdate(ScoreManager.instance.score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScoreUpdate(int score)
    {
        scoreText.text = score.ToString();
    }
}
