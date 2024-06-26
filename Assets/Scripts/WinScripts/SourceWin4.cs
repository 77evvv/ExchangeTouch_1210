using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceWin4 : MonoBehaviour
{
    public GameObject planePrefab; // 飞机的预制体

    void Start()
    {
        planePrefab.SetActive(false); // 初始状态为非激活状态

        float delayInSeconds = 2 * 60 + 25; // 将2分60秒转换为秒数
        Invoke("SpawnMyPlane", delayInSeconds); // 两分12秒后调用 SpawnMyPlane 方法
    }

    void SpawnMyPlane()
    {
        // 在这里将 Plane 对象设为激活状态
        planePrefab.SetActive(true);
    }
}