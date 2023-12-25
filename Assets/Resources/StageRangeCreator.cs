using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//此程式是把四軌音軌位置確定出來，存取資料
[CreateAssetMenu(fileName = "音軌位置資料", menuName = "新建音軌資料",order = 1)]
public class StageRangeCreator : ScriptableObject
{
    [Header("0 = 左邊X"), Space(height: 1), Header("1 = 右邊X"), Space(height: 1), Header("2 = 上面Y"), Space(height: 1),
     Header("3 = 下面Y"), Space(height: 1)]
    //public bool a;無功用1222
    public bool a;
    public float[] R1, R2, L1, L2;
}
