using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTBR : MonoBehaviour
{
    public float startBrightnessMultiplier = 0.5f; // 開始時的亮度乘數
    public float breathingSpeed = 1.0f; // 呼吸速度
    public float breathingRange = 0.2f; // 呼吸範圍
    public float initialDuration = 20.0f; // 初始閃爍的持續時間
    public float fadeDuration = 1.0f; // 淡出淡入的持續時間

    private float originalBrightness;
    private SpriteRenderer spriteRenderer;
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalBrightness = spriteRenderer.color.maxColorComponent;
        spriteRenderer.color = new Color(originalBrightness * startBrightnessMultiplier,
            originalBrightness * startBrightnessMultiplier,
            originalBrightness * startBrightnessMultiplier);

        StartCoroutine(FlashEffect());
    }

    IEnumerator FlashEffect()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < initialDuration)
        {
            float brightnessOffset = Mathf.Sin(Time.time * breathingSpeed) * breathingRange;
            float newBrightness = originalBrightness + brightnessOffset;
            spriteRenderer.color = new Color(newBrightness, newBrightness, newBrightness);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 開始黑色閃爍
        spriteRenderer.color = Color.green;
        yield return new WaitForSeconds(1.0f); // 閃爍綠色 1 秒

        // 開始黃色閃爍
        spriteRenderer.color = Color.yellow;
        yield return new WaitForSeconds(1.0f); // 閃爍黃色 1 秒
        spriteRenderer.color = Color.cyan;
        yield return new WaitForSeconds(1.0f); // 閃爍黃色 1 秒
        spriteRenderer.color = Color.magenta;
        yield return new WaitForSeconds(1.0f); // 閃爍綠色 1 秒
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1.0f); // 閃爍綠色 1 秒

        // 淡出效果
        float fadeTimer = 0.0f;
        Color originalColor = spriteRenderer.color;

        while (fadeTimer < fadeDuration)
        {
            float t = fadeTimer / fadeDuration;
            spriteRenderer.color =new Color(168f / 255f, 168f / 255f, 168f / 255f, 1f);
            fadeTimer += Time.deltaTime;
            yield return null;
        }

        // 在這裡停用腳本或進行其他操作
        Destroy(this);
    }
}