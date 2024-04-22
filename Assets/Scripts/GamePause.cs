using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPaused;
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
        string s1SceneName = "SceneS1";

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

    public void ReLevel3()
    {
        // 获取 S2 场景的名称
        string s3SceneName = "SceneS3";

        // 重新加载 S2 场景
        SceneManager.LoadScene(s3SceneName);
        Stopplane.SetActive(false);
        Time.timeScale = 1f; // 确保时间尺度正常

        // 在这里重新设置音频，例如停止和播放音频
        AudioListener.pause = false; // 恢复音频播放
    }
    public void ReLevel4()
    {
        // 获取 S2 场景的名称
        string s4SceneName = "SceneS4";

        // 重新加载 S2 场景
        SceneManager.LoadScene(s4SceneName);
        Stopplane.SetActive(false);
        Time.timeScale = 1f; // 确保时间尺度正常

        // 在这里重新设置音频，例如停止和播放音频
        AudioListener.pause = false; // 恢复音频播放
    }
    public void Opening()
    {
        // 获取 S2 场景的名称
        string OP = "Opeing0415";

        // 重新加载 S2 场景
        SceneManager.LoadScene(OP);
        Stopplane.SetActive(false);
        Time.timeScale = 1f; // 确保时间尺度正常

        // 在这里重新设置音频，例如停止和播放音频
        AudioListener.pause = false; // 恢复音频播放
    }
    public void Learn01()
    {
        // 获取 S1 场景的名称
        string Learn01Name = "SceneS01";

        // 重新加载 S1 场景
        SceneManager.LoadScene(Learn01Name);
        Stopplane.SetActive(false);
        Time.timeScale = 1f; // 确保时间尺度正常

        // 在这里重新设置音频，例如停止和播放音频
        AudioListener.pause = false; // 恢复音频播放
    }
    public void Learn02()
    {
        // 获取 S1 场景的名称
        string Learn02Name = "SceneS02";

        // 重新加载 S1 场景
        SceneManager.LoadScene(Learn02Name);
        Stopplane.SetActive(false);
        Time.timeScale = 1f; // 确保时间尺度正常

        // 在这里重新设置音频，例如停止和播放音频
        AudioListener.pause = false; // 恢复音频播放
    }
}
