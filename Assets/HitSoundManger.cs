using UnityEngine;
using UnityEngine.UI;

public class HitSoundManger : MonoBehaviour
{
    public AudioClip soundEffect; // 声音效果
    public Button yourButton; // 你的按钮

    private bool canPlay = false;

    void Start()
    {
        yourButton.onClick.AddListener(PlaySoundEffect);
    }

    void Update()
    {
        if (canPlay)
        {
            // 创建一个新的 AudioSource 对象
            GameObject audioPlayer = new GameObject("AudioPlayer");
            AudioSource audioSource = audioPlayer.AddComponent<AudioSource>();

            // 播放音效
            audioSource.PlayOneShot(soundEffect);

            // 在音频播放完后销毁新创建的 AudioSource
            Destroy(audioPlayer, soundEffect.length);

            // 设置为 false，避免重复播放
            canPlay = false;
        }
    }

    public void PlaySoundEffect()
    {
        // 当用户点击按钮时，允许播放音效
        canPlay = true;
    }
}