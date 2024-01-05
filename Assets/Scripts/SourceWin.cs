using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceWin : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip yourMusicClip; // 要播放的音樂檔案
    public GameObject myObject; // 包含 Plane 的遊戲物件

    int playCount = 0; // 用于计数播放次数

    void Start()
    {
        // 設置音樂檔案
        audioSource.clip = yourMusicClip;

        // 播放音樂
        PlayAudio();
    }

    void PlayAudio()
    {
        if (playCount < 2)
        {
            audioSource.Play();
            playCount++;
        }
    }

    void Update()
    {
        // 检查音乐是否已经播放完毕，并且确保只执行两次
        if (!audioSource.isPlaying && playCount < 2)
        {
            // 重新播放音乐
            PlayAudio();
        }
        else if (!audioSource.isPlaying && playCount == 2)
        {
            // 在音乐播放两次后开启 Plane
            myObject.SetActive(true);
        }
    }
}