using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    public List<int> gameHit = new List<int>();
    public int totalscore;
    public Text scoreText;
    private int perfectCount;
    private int niceCount;
    private int badCount;
    private int missCount;
    private int combeoCount;

    // Start is called before the first frame update
    void Start()
    {
        perfectCount = 0;
        niceCount = 0;
        badCount = 0;
        missCount = 0;
        combeoCount = 0;
        totalscore = 0;
        UpdateScoreDisplay(); // 初始顯示分數
    }

    // 更新分數顯示
    void UpdateScoreDisplay()
    {
        string formattedScore = totalscore.ToString("D9"); // 格式化分數為固定寬度9位，不足的位數補0
        scoreText.text = formattedScore;
    }

    // 加分機制 NICE/PERFECT/BAD/MISS
    public void showScore(int aa)
    {
        switch (aa)
        {
            case 0:
                // bad
                totalscore += 400;
                badCount++;
                break;
            case 1:
                // nice
                totalscore += 550;
                niceCount++;
                break;
            case 2:
                // perfect
                totalscore += 700;
                perfectCount++;
                break;
            case 3:
                //Miss
                missCount++;
                break;
        }

        UpdateScoreDisplay();
        SaveScore(); // 更新顯示分數
    }

    /*
     public void CountScore()
    {
        totalscore = 0;
        foreach (int noteNow in gameHit)
        {
            switch (noteNow)
            {
                case 0:
                    break;
                case 1:
                    totalscore += 100;
                    break;
                case 2:
                    totalscore += 200;
                    break;
                case 3:
                    totalscore += 300;
                    break;
            }
        }
        */
    
    

        public void SaveScore()
    {
        PlayerPrefs.SetInt("FinalScore", totalscore);
        PlayerPrefs.SetInt("PerfectCount", perfectCount);
        PlayerPrefs.SetInt("NiceCount", niceCount);
        PlayerPrefs.SetInt("BadCount", badCount);
        PlayerPrefs.SetInt("MissCount", missCount);
        PlayerPrefs.Save();
    }

}
