using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lv0HitOver : MonoBehaviour
{
    public AudioClip musicClip; // 音乐片段
    private AudioSource audioSource;
    private int playCount = 0; // 播放计数

    public GameObject planePrefab; // 飞机的预制体

    //private bool hasSpawnedPlane = false; // 用于跟踪飞机是否已生成

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = false; // 禁用循环播放
        PlayMusic(); // 开始播放音乐

        planePrefab.SetActive(false); // 初始状态为非激活状态
    }

    void Update()
    {
        // 当音乐播放完成时
        if (!audioSource.isPlaying && playCount < 2)
        {
            if (playCount < 1) // 只有在播放次数小于1（第一次播放）时才播放音乐
            {
                PlayMusic();
                playCount++;
            }
            else // 当播放次数为1（第二次）时，不再播放音乐，而是生成飞机
            {
                SpawnMyPlane();
                playCount++;
            }
        }
    }

    void PlayMusic()
    {
        audioSource.Play();
    }

    void SpawnMyPlane()
    {
        // 在这里将 Plane 对象设为激活状态
        planePrefab.SetActive(true);
    }
}