using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button PauseButton;
    public GameObject PauseWindow;
    public AudioSource audioSource;
    public GameObject endPlane;

    private bool isMusicPlaying;
    private bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        isMusicPlaying = false;

        PauseButton.onClick.AddListener(PauseGame);
        StopOpen(); // 添加此行调用
    }

    // Update is called once per frame
    void Update()
    {
        if (isMusicPlaying && !audioSource.isPlaying)
        {
            ShowEndPlane();
        }
    }

    public void StopOpen()
    {
        PauseWindow.SetActive(false);
    }

    public void PauseGame()
    {
        isPause = !isPause;

        if (isPause)
        {
            PauseWindow.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = true; // 暂停所有音频

            if (!isMusicPlaying)
            {
                PlayMusic();
            }
        }
        else
        {
            PauseWindow.SetActive(false);
            Time.timeScale = 1;
            AudioListener.pause = false; // 取消暂停音频
            StopOpen(); // 添加此行调用
        }
    }

    public void PlayMusic()
    {
        audioSource.Play();
        isMusicPlaying = true;
    }

    private void ShowEndPlane()
    {
        endPlane.SetActive(true);
    }
}