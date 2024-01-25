using UnityEngine;
using UnityEngine.SceneManagement;

public class DonStopMusic : MonoBehaviour
{
    private static  DonStopMusic instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 使该对象在场景切换时不被销毁
        }
        else
        {
            Destroy(gameObject); // 如果已经存在其他实例，则销毁该实例
        }
    }

    public void PlayMusic()
    {
        // 在此播放音乐的相关代码
        // 例如：AudioSource.Play();
    }
}

public partial class PauseGame : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject Stopplane;
    private  DonStopMusic audioManager;

    void Start()
    {
        audioManager = FindObjectOfType< DonStopMusic>(); // 找到音频管理器对象
        if (audioManager != null)
        {
            audioManager.PlayMusic(); // 开始播放音乐
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // 更改为你想要的暂停键
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseStop();
            }
        }
    }

    public void PauseStop()
    {
        Time.timeScale = 0f;
        isPaused = true;
        Stopplane.SetActive(true);
        AudioListener.pause = true; // 暂停所有音频
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Stopplane.SetActive(false);
        AudioListener.pause = false; // 恢复音频播放
    }

    // 此为重新加载场景
    public void RestartLevel1()
    {
        // 获取 S1 场景的名称
        string s1SceneName = "S1";

        // 重新加载 S1 场景
        SceneManager.LoadScene(s1SceneName);
        Time.timeScale = 1f; // 确保时间尺度正常
    }

    public void RestartLevel2()
    {
        // 获取 S2 场景的名称
        string s2SceneName = "SceneS2";

        // 重新加载 S2 场景
        SceneManager.LoadScene(s2SceneName);
        Time.timeScale = 1f; // 确保时间尺度正常
    }
}