using TMPro;
using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    // [SerializeField]
    private TMPro.TextMeshProUGUI scoreText;
    // [SerializeField]
    private TMPro.TextMeshProUGUI timeText;
    // [SerializeField]
    private TMPro.TextMeshProUGUI historyText;
    // [SerializeField]
    private TMPro.TextMeshProUGUI healthText;

    private float gameTime;

    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();
        timeText = GameObject.Find("TimeText").GetComponent<TMPro.TextMeshProUGUI>();
        historyText = GameObject.Find("HistoryText").GetComponent<TMPro.TextMeshProUGUI>();
        healthText = GameObject.Find("HealthText").GetComponent<TMPro.TextMeshProUGUI>();
        gameTime = 0f;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        
        // Convert time to MM:SS.ms format
        int minutes = Mathf.FloorToInt(gameTime / 60f);
        int seconds = Mathf.FloorToInt(gameTime % 60f);
        int milliseconds = Mathf.FloorToInt((gameTime * 100f) % 100f);
        timeText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);

        scoreText.text = CircleScript.score.ToString();
        historyText.text = ScoreHistory.GetFormattedHistory();
        
        // Display hearts as text
        healthText.text = $"{CircleScript.health} Hearts";
    }
}
