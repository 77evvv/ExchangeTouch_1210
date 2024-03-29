using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UserData1
{
    public int perfectCount;
    public int niceCount;
    public int badCount;
    public int missCount;
    public int totalScore;
}

public class GameMain : MonoBehaviour
{
    // 游戏中的击中列表和总分数
    public List<int> gameHit = new List<int>();
    public int totalscore;

    // UI 元素：显示分数的文本
    public Text scoreText;

    // 击中计数器：Perfect、Nice、Bad、Miss
    private int perfectCount;
    private int niceCount;
    private int badCount;
    private int missCount;

    // Boss 相关
    public Animator bossAni;
    private float attackDelayTimer = 0f; // 攻击延迟计时器
    private bool canAttack = false; // 是否可以攻击;
    public string bossHurtAnimationName = "Lv1BossAttack";
    public string bossBreathAnimationName = "LV1BossBreath";

    // 当前关卡名称
    public static string currentLevelName; // 将 currentLevelName 定义为静态属性

    // 结算画面的 UI 元素（假设是一个 Plane）

    // 保存分数数据的对象
    private UserData1 scoreData = new UserData1();

    // 游戏开始时初始化相关变量
    void Start()
    {
        perfectCount = 0;
        niceCount = 0;
        badCount = 0;
        missCount = 0;
        totalscore = 0;
        UpdateScoreDisplay(); // 初始化显示分数

        currentLevelName = SceneManager.GetActiveScene().name;

        // 查找并获取 Boss 的 Animator 组件
        GameObject bossObject = GameObject.Find(bossBreathAnimationName);
        if (bossObject != null)
        {
            bossAni = bossObject.GetComponent<Animator>();
            if (bossAni == null)
            {
                Debug.Log("Animator component not found on bossObject.");
            }
        }
        else
        {
            Debug.Log("Boss GameObject not found.");
        }

        Invoke("EnableAttack", 20f); // 在游戏开始后 20 秒后调用 EnableAttack 方法
    }

    void EnableAttack()
    {
        canAttack = true;
    }

    // 更新分数显示
    void UpdateScoreDisplay()
    {
        string formattedScore = totalscore.ToString("D9");
        scoreText.text = formattedScore;
    }

    // 处理击中事件，并更新分数和计数器
    public void showScore(int aa)
    {
        switch (aa)
        {
            case 0:
                totalscore += 400;
                badCount++;
                break;
            case 1:
                totalscore += 550;
                niceCount++;
                BossAttacked(true, bossHurtAnimationName);
                break;
            case 2:
                totalscore += 700;
                perfectCount++;
                BossAttacked(true, bossHurtAnimationName);
                break;
            case 3:
                missCount++;
                break;
        }

        UpdateScoreDisplay();
        SaveScore();
        // 显示结算画面
        ShowScoreFinally();
    }

    // 处理 Boss 被攻击的逻辑
    public void BossAttacked(bool attacked, string animationName)
    {
        if (canAttack) // 添加了对 canAttack 的检查
        {
            if (attacked)
            {
                int randomValue = Random.Range(50, 101);
                if (randomValue % 5 == 0)
                {
                    canAttack = true;
                    PlayAttackAnimation(animationName);
                }
            }
            else
            {
                canAttack = false;
                bossAni.Play(animationName);
            }
        }
    }

    // 播放 Boss 受伤动画
    void PlayAttackAnimation(string animationName)
    {
        canAttack = true;
        bossAni.Play(animationName);
    }

    // 保存分数和计数器到 PlayerPrefs
    public void SaveScore()
    {
        string levelKey = currentLevelName + "_"; // 添加关卡名称前缀
        scoreData.perfectCount = perfectCount;
        scoreData.niceCount = niceCount;
        scoreData.badCount = badCount;
        scoreData.missCount = missCount;
        scoreData.totalScore = totalscore;

        // 将 UserData 对象转换为 JSON 格式的字符串
        string json = JsonUtility.ToJson(scoreData);

        // 构建存档路径和文件名
        string filePath = "Assets/Resources/" + levelKey + "ScoreData.json";

        // 将 JSON 字符串写入文件
        System.IO.File.WriteAllText(filePath, json);

        Debug.Log("JSON 文件保存成功：" + filePath);
    }

    // 显示结算画面的方法
    void ShowScoreFinally()
    {
        // 获取当前关卡的索引，假设关卡命名规则为 SceneS1、SceneS2、SceneS3 等
        int levelIndex = int.Parse(currentLevelName.Replace("SceneS", ""));

        // 根据关卡索引决定传递的数值
        switch (levelIndex)
        {
            case 1:
                ScoreFinallyLv1.perfectCountValue = perfectCount;
                ScoreFinallyLv1.niceCountValue = niceCount;
                ScoreFinallyLv1.badCountValue = badCount;
                ScoreFinallyLv1.missCountValue = missCount;
                ScoreFinallyLv1.totalScoreValue = totalscore;
                break;
            case 2:
                ScoreFinallyLv2.perfectCountValue = perfectCount;
                ScoreFinallyLv2.niceCountValue = niceCount;
                ScoreFinallyLv2.badCountValue = badCount;
                ScoreFinallyLv2.missCountValue = missCount;
                ScoreFinallyLv2.totalScoreValue = totalscore;
                break;
            case 3:
                ScoreFinallyLv3.perfectCountValue = perfectCount;
                ScoreFinallyLv3.niceCountValue = niceCount;
                ScoreFinallyLv3.badCountValue = badCount;
                ScoreFinallyLv3.missCountValue = missCount;
                ScoreFinallyLv3.totalScoreValue = totalscore;
                break;
            case 4:
                ScoreFinallyLv4.perfectCountValue = perfectCount;
                ScoreFinallyLv4.niceCountValue = niceCount;
                ScoreFinallyLv4.badCountValue = badCount;
                ScoreFinallyLv4.missCountValue = missCount;
                ScoreFinallyLv4.totalScoreValue = totalscore;
                break;
            default:
                // 默认处理逻辑，可能在这里给出提示或者处理错误情况
                break;
        }
    }
}