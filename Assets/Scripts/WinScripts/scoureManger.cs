using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoureManger : MonoBehaviour
{ 
    private static scoureManger _instance;

    public static scoureManger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<scoureManger>();

                if (_instance == null)
                {
                    GameObject managerObject = new GameObject("ScoreManager");
                    _instance = managerObject.AddComponent<scoureManger>();
                }
            }
            return _instance;
        }
    }

    // 保存分数数据的方法，传入关卡索引和要保存的数据
    public void SaveScore(int sceneIndex, int totalScore, int perfectCount, int niceCount, int badCount, int missCount)
    {
        PlayerPrefs.SetInt("TotalScore_" + sceneIndex, totalScore);
        PlayerPrefs.SetInt("PerfectCount_" + sceneIndex, perfectCount);
        PlayerPrefs.SetInt("NiceCount_" + sceneIndex, niceCount);
        PlayerPrefs.SetInt("BadCount_" + sceneIndex, badCount);
        PlayerPrefs.SetInt("MissCount_" + sceneIndex, missCount);
        PlayerPrefs.Save();
        
        Debug.Log("Saved scores for scene " + sceneIndex);
    }

    // 加载分数数据的方法，传入关卡索引
    public void LoadScore(int sceneIndex)
    {
        int totalScore = PlayerPrefs.GetInt("TotalScore_" + sceneIndex, 0);
        int perfectCount = PlayerPrefs.GetInt("PerfectCount_" + sceneIndex, 0);
        int niceCount = PlayerPrefs.GetInt("NiceCount_" + sceneIndex, 0);
        int badCount = PlayerPrefs.GetInt("BadCount_" + sceneIndex, 0);
        int missCount = PlayerPrefs.GetInt("MissCount_" + sceneIndex, 0);

        // 在这里可以根据需要使用加载的数据进行操作，比如更新UI显示等
        Debug.Log("Loaded scores for scene " + sceneIndex);
    }

    // 其他分数管理逻辑...
}