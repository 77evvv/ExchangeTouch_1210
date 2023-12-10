using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instence = null;

    private AudioSource _audio;
    public GameObject stopPanel;
    // Start is called before the first frame update
    
    void Awake()
    {
        if (instence == null)
        {
            instence = this;
        }
    }

    // Update is called once per frame
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!_audio.isPlaying) // 檢查音樂是否停止播放
        {
            stopPanel.SetActive(true); // 顯示停止面板
        }
    }
    
}
