using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using System;
public class func : MonoBehaviour
{
    public List<Move> myNote = new List<Move>();
   //此檔案為測試觸控是否有被偵測到1208
    public void 嘗試擊中音符()
    {
        if (myNote.Count != 0)
        {
            //Debug.Log("不是空的");
            myNote[0].detectNote();
        }
        else
        {
                
            //Debug.Log("空的");
        }
    }
}
