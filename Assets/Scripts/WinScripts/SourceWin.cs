using UnityEngine;
using UnityEngine.UI;

public class SourceWin : MonoBehaviour
{
    public GameObject planePrefab; // 飞机的预制体

    void Start()
    {
        planePrefab.SetActive(false); // 初始状态为非激活状态

        float delayInSeconds = 2 * 60 + 12; // 将2分12秒转换为秒数
        Invoke("SpawnMyPlane", delayInSeconds); // 两分12秒后调用 SpawnMyPlane 方法
    }

    void SpawnMyPlane()
    {
        // 在这里将 Plane 对象设为激活状态
        planePrefab.SetActive(true);
    }
}
