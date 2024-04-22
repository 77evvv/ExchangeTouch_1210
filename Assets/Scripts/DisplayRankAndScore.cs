using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DisplayRankAndScore : MonoBehaviour
{
    public Text fileNameText;
    public Text perfectCountText;
    public Text niceCountText;
    public Text badCountText;
    public Text missCountText;
    public Text totalScoreText;
    public Text rankText;

    void Start()
    {
        // 获取当前关卡名称
        string currentLevelName = SceneManager.GetActiveScene().name;

        // 获取 JSON 文件名并显示在 UI 中
        string fileName = currentLevelName + "_ScoreData.json";
        fileNameText.text = "File Name: " + fileName;

        // 读取 JSON 文件
        TextAsset jsonFile = Resources.Load<TextAsset>(currentLevelName + "_ScoreData");
        if (jsonFile != null)
        {
            // 解析 JSON 数据为 UserData1 对象
            UserData1 scoreData = JsonUtility.FromJson<UserData1>(jsonFile.text);

            // 更新 UI Text 显示
            perfectCountText.text = "Perfect Count: " + scoreData.perfectCount.ToString();
            niceCountText.text = "Nice Count: " + scoreData.niceCount.ToString();
            badCountText.text = "Bad Count: " + scoreData.badCount.ToString();
            missCountText.text = "Miss Count: " + scoreData.missCount.ToString();
            totalScoreText.text = "Total Score: " + scoreData.totalScore.ToString();

            // 调用显示排名信息的方法
            DisplayRank();
        }
        else
        {
            Debug.LogError("JSON file not found or loaded.");
        }
    }

    // 新增显示排名信息的方法
    private void DisplayRank()
    {
        // 指定关卡名称为 "SceneS2"
        string currentLevelName = "SceneS2";

        // 获取 JSON 文件名并显示在 UI 中
        

        // 读取 JSON 文件
        TextAsset jsonFile = Resources.Load<TextAsset>(currentLevelName + "_RankData");
        if (jsonFile != null)
        {
            // 解析 JSON 数据为 RankData 对象
            RankData rankData = JsonUtility.FromJson<RankData>(jsonFile.text);

            // 更新 UI Text 显示
            rankText.text = "Rank: " + rankData.rank;
        }
        else
        {
            Debug.LogError("JSON file not found or loaded.");
        }
    }
}