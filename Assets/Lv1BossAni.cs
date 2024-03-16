using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv1BossAni : MonoBehaviour
{
    public Animator bossAni;
    private bool isAttacking = false;
    public GameMain MBBcount;

    void Start()
    {
        // 获取Boss的Animator组件
        bossAni = GameObject.Find("LEVEL1").GetComponent<Animator>();

        // 获取GameMain组件
        MBBcount = FindObjectOfType<GameMain>();

        // 在这里检查MBBcount是否是5的倍数，如果是则播放攻击动画
        if (MBBcount != null && MBBcount.MBBcount % 5 == 0)
        {
            PlayAttackAnimation(); // 播放攻击动画
        }
    }

    // 播放攻击动画
    void PlayAttackAnimation()
    {
        // 设置为攻击状态
        isAttacking = true;
        // 播放攻击动画
        bossAni.Play("LEVEL1BossAttack");
    }

    // 当Boss受到攻击时调用
    public void BossAttacked(bool attacked)
    {
        if (attacked)
        {
            // 获取 MBBcount 的值
            if (MBBcount != null)
            {
                int mbCount = MBBcount.MBBcount;

                // 检查 MBBcount 是否是 5 的倍数，如果是则播放攻击动画
                if (mbCount % 5 == 0)
                {
                    PlayAttackAnimation(); // 播放攻击动画
                }
            }
            else
            {
                Debug.LogError("MBBcount not found!");
            }
        }
        else
        {
            // 设置为呼吸动画
            isAttacking = false;
            bossAni.Play("LEVEL1");
        }
    }
}