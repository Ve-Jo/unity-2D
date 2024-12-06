using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private TMPro.TextMeshProUGUI messageText;

    private bool isGameOver = false;
    private bool isFinalGameOver = false;
    private bool hasRecordedScore = false;
    private GameObject tubeToRemove = null;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = content.activeInHierarchy ? 1.0f : 0.0f;
            content.SetActive(!content.activeInHierarchy);
        }
    }

    public void ShowMessage(string message, GameObject tube = null, bool finalGameOver = false)
    {
        Time.timeScale = 0.0f;
        content.SetActive(true);
        messageText.text = message;
        isGameOver = true;
        isFinalGameOver = finalGameOver;
        
        if (isFinalGameOver && !hasRecordedScore)
        {
            // Only add score to history once on final game over
            ScoreHistory.AddScore(CircleScript.score);
            hasRecordedScore = true;
        }
        
        tubeToRemove = tube;
    }

    public void OnResumeClick()
    {
        if (isFinalGameOver)
        {
            // If it's final game over, restart instead of resume
            OnRestartClick();
            return;
        }

        if (isGameOver && tubeToRemove != null)
        {
            Destroy(tubeToRemove);
            tubeToRemove = null;
            isGameOver = false;
        }
        Time.timeScale = 1.0f;
        content.SetActive(false);
        Debug.Log("Resume click");
    }
    
    public void OnRestartClick()
    {
        // Record score if player manually restarts and hasn't recorded score yet
        if (isGameOver && !hasRecordedScore && CircleScript.score > 0)
        {
            ScoreHistory.AddScore(CircleScript.score);
        }
        hasRecordedScore = false;  // Reset the flag when restarting
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        content.SetActive(false);
    }
}
