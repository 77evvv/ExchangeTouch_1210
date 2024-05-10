using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO; // 添加此命名空间以使用文件操作

[System.Serializable]
public class RankData
{
    public string rank;
}

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

    // 新增静态属性用于接收传递过来的值
    public static int perfectCountValue;
    public static int niceCountValue;
    public static int badCountValue;
    public static int missCountValue;
    public static int totalScoreValue;

    public string currentLevelName; // 定义场景名称变量

    void Start()
    {
        // 开始时先关闭这四个 Image
        imageS.SetActive(false);
        imageA.SetActive(false);
        imageB.SetActive(false);
        imageC.SetActive(false);

        // 将传递过来的值赋给显示文本
        Perfect.text = perfectCountValue.ToString("D3");
        Nice.text = niceCountValue.ToString("D3");
        Bad.text = badCountValue.ToString("D3");
        Miss.text = missCountValue.ToString("D3");
        finalScoreText.text = totalScoreValue.ToString("D9");

        // 初始化当前关卡名称
        currentLevelName = SceneManager.GetActiveScene().name;

        GetRank();
    }

    public void GetRank()
    {
        int finalScore = int.Parse(finalScoreText.text);
        float percentage = ((float)finalScore / 79800f) * 100f;

        //string rank = "C"; // 默认为 C 级别

        if (percentage >= 90f)
        {
            imageS.SetActive(true);
            //rank = "S";
        }
        else if (percentage >= 80f)
        {
            imageA.SetActive(true);
            //rank = "A";
        }
        else if (percentage >= 70f)
        {
            imageB.SetActive(true);
            //rank = "B";
        }
        else
        {
            imageC.SetActive(true);
        }

        // 保存评级数据到 JSON 文件
        //SaveRankToJSON(rank);
    }

    /*public void SaveRankToJSON(string rank)
    {
        // 创建保存评级数据的对象
        RankData rankData = new RankData();
        rankData.rank = rank;

        // 将评级数据转换为 JSON 格式的字符串
        string json = JsonUtility.ToJson(rankData);

        // 构建存档路径和文件名
        string fileName = currentLevelName + "_RankData.json";
        string filePath = Path.Combine(Application.dataPath, "Resources", fileName); // 获取资源文件夹路径

        // 将 JSON 字符串写入文件
        File.WriteAllText(filePath, json);

        // 刷新资源文件夹，以便 Unity Editor 可以立即检测到文件变化
        //UnityEditor.AssetDatabase.Refresh();

        Debug.Log("JSON RANK文件保存成功：" + fileName);
    }*/
}