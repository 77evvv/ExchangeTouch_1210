using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
     public List<int> gameHit = new List<int>();
    public int totalscore;
    public Text scoreText;
    private int perfectCount;
    private int niceCount;
    private int badCount;
    private int missCount;
    public int MBBcount;
    public Animator bossAni;
    private bool isAttacking = false;

    // 受伤的 Boss 名称
    public string bossHurtAnimationName = "Lv1BossAttack";
    // 呼吸的 Boss 名称
    public string bossBreathAnimationName = "LV1BossBreath";

    // Start is called before the first frame update
    void Start()
    {
        bossAni = GameObject.Find(bossBreathAnimationName).GetComponent<Animator>();
        perfectCount = 0;
        niceCount = 0;
        badCount = 0;
        missCount = 0;
        totalscore = 0;
        MBBcount = 0;
        UpdateScoreDisplay(); // 初始顯示分數
    }

    // 更新分數顯示
    void UpdateScoreDisplay()
    {
        string formattedScore = totalscore.ToString("D9"); // 格式化分數為固定寬度9位，不足的位數補0
        scoreText.text = formattedScore;
    }

    // 加分機制 NICE/PERFECT/BAD/MISS
    public void showScore(int aa)
    {
        switch (aa)
        {
            case 0:
                // bad
                totalscore += 400;
                MBBcount++;
                badCount++;
                break;
            case 1:
                // nice
                totalscore += 550;
                MBBcount++;
                niceCount++;
                BossAttacked(true, bossHurtAnimationName);
                break;
            case 2:
                // perfect
                totalscore += 700;
                MBBcount++;
                perfectCount++;
                BossAttacked(true, bossHurtAnimationName);
                break;
            case 3:
                //Miss
                missCount++;
                break;
        }

        UpdateScoreDisplay();
        SaveScore(); // 更新顯示分數
    }

    public void BossAttacked(bool attacked, string animationName)
    {
        if (attacked)
        {
            int randomValue = Random.Range(50, 101);

            // 当随机值是 5 的倍数时，播放攻击动画
            if (randomValue % 5 == 0)
            {
                PlayAttackAnimation(animationName); // 播放攻击动画
            }
        }
        else
        {
            // 设置为呼吸动画
            isAttacking = false;
            bossAni.Play(animationName);
        }
    }

    // 播放攻击动画
    void PlayAttackAnimation(string animationName)
    {
        // 设置为攻击状态
        isAttacking = true;
        // 播放受伤的 Boss 动画
        bossAni.Play(animationName);
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("FinalScore", totalscore);
        PlayerPrefs.SetInt("PerfectCount", perfectCount);
        PlayerPrefs.SetInt("NiceCount", niceCount);
        PlayerPrefs.SetInt("BadCount", badCount);
        PlayerPrefs.SetInt("MissCount", missCount);
        PlayerPrefs.Save();
    }
}