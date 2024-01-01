using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour
{
    public Text finalScoreText;

    void Start()
    {
        // 從本地讀取分數
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);

        // 在結算畫面上顯示最終分數
        string formattedScore = finalScore.ToString("D9");
        finalScoreText.text = formattedScore;
    }
}
