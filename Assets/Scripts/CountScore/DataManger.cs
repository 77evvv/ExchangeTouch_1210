using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManger : MonoBehaviour
{
    public static DataManger Instance;

    // 定义需要保存的数据
    public int[] totalScores = new int[4]; // 每个关卡的总分
    public int[] perfectCounts = new int[4]; // 每个关卡的perfect数量
    public int[] niceCounts = new int[4]; // 每个关卡的nice数量
    public int[] badCounts = new int[4]; // 每个关卡的bad数量
    public int[] missCounts = new int[4]; // 每个关卡的miss数量

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 保证场景切换时不销毁该对象
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 保存数据的方法
    public void SaveData(int sceneIndex)
    {
        PlayerPrefs.SetInt("TotalScore_" + sceneIndex, totalScores[sceneIndex]);
        PlayerPrefs.SetInt("PerfectCount_" + sceneIndex, perfectCounts[sceneIndex]);
        PlayerPrefs.SetInt("NiceCount_" + sceneIndex, niceCounts[sceneIndex]);
        PlayerPrefs.SetInt("BadCount_" + sceneIndex, badCounts[sceneIndex]);
        PlayerPrefs.SetInt("MissCount_" + sceneIndex, missCounts[sceneIndex]);
        PlayerPrefs.Save();
    }

    // 加载数据的方法
    public void LoadData(int sceneIndex)
    {
        totalScores[sceneIndex] = PlayerPrefs.GetInt("TotalScore_" + sceneIndex, 0);
        perfectCounts[sceneIndex] = PlayerPrefs.GetInt("PerfectCount_" + sceneIndex, 0);
        niceCounts[sceneIndex] = PlayerPrefs.GetInt("NiceCount_" + sceneIndex, 0);
        badCounts[sceneIndex] = PlayerPrefs.GetInt("BadCount_" + sceneIndex, 0);
        missCounts[sceneIndex] = PlayerPrefs.GetInt("MissCount_" + sceneIndex, 0);
    }
}