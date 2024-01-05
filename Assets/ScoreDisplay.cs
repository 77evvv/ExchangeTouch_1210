using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text finalScoreText;
    public Text Perfect;
    public Text Nice;
    public Text Bad;
    public Text Miss;

    void Start()
    {
        // 在結算畫面上顯示最終分數
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        string formattedScore = finalScore.ToString("D9");
        finalScoreText.text = formattedScore;

        // 显示计数器的值
        int perfectCount = PlayerPrefs.GetInt("PerfectCount", 0);
        Perfect.text = perfectCount.ToString();

        int niceCount = PlayerPrefs.GetInt("NiceCount", 0);
        Nice.text = niceCount.ToString();

        int badCount = PlayerPrefs.GetInt("BadCount", 0);
        Bad.text = badCount.ToString();

        int missCount = PlayerPrefs.GetInt("MissCount", 0);
        Miss.text = missCount.ToString();
    }
}