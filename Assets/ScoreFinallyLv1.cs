using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFinallyLv1 : MonoBehaviour
{
    public Text finalScoreText;
    public Text Perfect;
    public Text Nice;
    public Text Bad;
    public Text Miss;

    public GameObject imageS;
    public GameObject imageA;
    public GameObject imageB;
    public GameObject imageC;

    void Start()
    {
        // 开始时先关闭这四个 Image
        imageS.SetActive(false);
        imageA.SetActive(false);
        imageB.SetActive(false);
        imageC.SetActive(false);

        // 在結算畫面上顯示最終分數
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        string formattedScore = finalScore.ToString("D9");
        finalScoreText.text = formattedScore;

        // 显示计数器的值，並進行格式化
        int perfectCount = PlayerPrefs.GetInt("PerfectCount", 0);
        Perfect.text = perfectCount.ToString("D3"); // 格式化為固定寬度 3 位數，不足的位數補 0

        int niceCount = PlayerPrefs.GetInt("NiceCount", 0);
        Nice.text = niceCount.ToString("D3"); // 格式化為固定寬度 3 位數，不足的位數補 0

        int badCount = PlayerPrefs.GetInt("BadCount", 0);
        Bad.text = badCount.ToString("D3"); // 格式化為固定寬度 3 位數，不足的位數補 0

        int missCount = PlayerPrefs.GetInt("MissCount", 0);
        Miss.text = missCount.ToString("D3"); // 格式化為固定寬度 3 位數，不足的位數補 0

        // 在 Start 方法中调用 GetRank 方法，根据 finalScoreText 的文本内容激活相应的 Image
        GetRank();
    }

    public void GetRank()
    {
        int finalScore = int.Parse(finalScoreText.text);
        float percentage = ((float)finalScore / 79800f) * 100f; // 计算得分百分比（假设第二关最高分为 144900）

        if (percentage >= 90f)
        {
            imageS.SetActive(true);
        }
        else if (percentage >= 80f)
        {
            imageA.SetActive(true);
        }
        else if (percentage >= 70f)
        {
            imageB.SetActive(true);
        }
        else
        {
            imageC.SetActive(true);
        }
    }
}
