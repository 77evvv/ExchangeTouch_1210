using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SourceWin : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip yourMusicClip; // 要播放的音樂檔案
    public GameObject myObject; // 包含 Plane 的遊戲物件

    void Start()
    {
        // 設置音樂檔案
        audioSource.clip = yourMusicClip;

        // 播放音樂
        audioSource.Play();
    }

    void Update()
    {
        // 檢查音樂是否已經播放完畢
        if (!audioSource.isPlaying)
        {
            // 在這裡開啟 Plane
            myObject.SetActive(true);
        }
    }
}