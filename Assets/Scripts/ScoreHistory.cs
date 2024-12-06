using System.Collections.Generic;
using UnityEngine;

public class ScoreHistory : MonoBehaviour
{
    private static List<int> scoreHistory = new List<int>();
    private static int highestScore = 0;
    public static List<int> History => scoreHistory;

    public static void AddScore(int score)
    {
        bool isNewRecord = score > highestScore;
        if (isNewRecord)
        {
            highestScore = score;
        }

        scoreHistory.Add(score);
        // Keep only last 10 scores
        if (scoreHistory.Count > 10)
        {
            scoreHistory.RemoveAt(0);
        }
    }

    public static string GetFormattedHistory()
    {
        string result = $"Record: {highestScore} points\n\nPrevious Scores:\n";
        for (int i = scoreHistory.Count - 1; i >= 0; i--)
        {
            string scoreText = $"Try {scoreHistory.Count - i}: {scoreHistory[i]} points";
            // Add a "NEW RECORD!" indicator if this score is the record
            if (scoreHistory[i] == highestScore && scoreHistory[i] > 0)
            {
                scoreText += " (RECORD!)";
            }
            result += scoreText + "\n";
        }
        return result;
    }
} 