using UnityEngine;
using UnityEngine.UI;

public class HitSoundManger : MonoBehaviour
{
    public AudioClip soundEffect; // 声音效果
    private AudioSource audioSource; // 声音播放器

    void Start()
    {
        // 添加 AudioSource 组件到当前游戏对象
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundEffect; // 设置音效
        audioSource.volume = 0.45f;
    }

    void Update()
    {
        // 检测玩家是否点击了屏幕
        if (Input.GetMouseButtonDown(0)) // 0 表示左键
        {
            // 播放音效
            audioSource.PlayOneShot(soundEffect);
        }
    }
}