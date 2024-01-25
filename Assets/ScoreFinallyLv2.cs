using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreFinallyLv2 : MonoBehaviour
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

        // 显示计数器的值
        int perfectCount = PlayerPrefs.GetInt("PerfectCount", 0);
        Perfect.text = perfectCount.ToString();

        int niceCount = PlayerPrefs.GetInt("NiceCount", 0);
        Nice.text = niceCount.ToString();

        int badCount = PlayerPrefs.GetInt("BadCount", 0);
        Bad.text = badCount.ToString();

        int missCount = PlayerPrefs.GetInt("MissCount", 0);
        Miss.text = missCount.ToString();

        // 在 Start 方法中调用 GetRank 方法，根据 finalScoreText 的文本内容激活相应的 Image
        GetRank();
    }

    public void GetRank()
    {
        int finalScore = int.Parse(finalScoreText.text);
        float percentage = ((float)finalScore / 144900f) * 100f; // 计算得分百分比（假设第二关最高分为 144900）

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
