using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPaused = false;
    public GameObject Stopplane;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // 更改为你想要的暂停键
        {
            if (isPaused)
            {
                ReGame();
            }
            else
            {
                PSStop();
            }
        }

    }

    public void PSStop()
    {
        Time.timeScale = 0f;
        isPaused = true;
        Stopplane.SetActive(true);
        AudioListener.pause = true; // 暂停所有音频
    }

    public void ReGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Stopplane.SetActive(false);
        AudioListener.pause = false; // 恢复音频播放
    }

    //此為重新加載場景
    public void ReLevel1()
    {
        // 获取 S1 场景的名称
        string s1SceneName = "S1";

        // 重新加载 S1 场景
        SceneManager.LoadScene(s1SceneName);
        Stopplane.SetActive(false);
        Time.timeScale = 1f; // 确保时间尺度正常

        // 在这里重新设置音频，例如停止和播放音频
        AudioListener.pause = false; // 恢复音频播放
    }

    public void ReLevel2()
    {
        // 获取 S2 场景的名称
        string s2SceneName = "SceneS2";

        // 重新加载 S2 场景
        SceneManager.LoadScene(s2SceneName);
        Stopplane.SetActive(false);
        Time.timeScale = 1f; // 确保时间尺度正常

        // 在这里重新设置音频，例如停止和播放音频
        AudioListener.pause = false; // 恢复音频播放
    }
}
