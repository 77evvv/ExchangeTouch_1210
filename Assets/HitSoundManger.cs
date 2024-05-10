using UnityEngine;
using UnityEngine.UI;



public class HitSoundManger : MonoBehaviour
{
    public AudioSource audioSource; // 声音播放器

    void Start()
    {
        if (audioSource == null)
        {
            //Debug.LogError("AudioSource未設置，請在編輯器中設置。");
            return;
        }

        // 设置音效
        audioSource.volume = 0.35f;
    }

    void Update()
    {
        // 检测玩家是否点击了屏幕
        if (Input.GetMouseButtonDown(0)) // 0 表示左键
        {
            Debug.Log("WHy");
            // 播放音效
            audioSource.Play();
        }
    }
}