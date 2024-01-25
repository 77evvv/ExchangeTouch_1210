using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class touchLocation
{
    public int touchId;
    //public GameObject circle;
    public GameObject[] 點擊方塊;
    public bool registed;
    //存取打擊範圍資料_1222
    public StageRangeCreator 本關音軌資料;
    public List<List<float>> 音軌範圍 = new List<List<float>>();
    public List<float> 左1清單= new List<float>();
    public List<float> 左2清單= new List<float>();
    public List<float> 右1清單= new List<float>();
    public List<float> 右2清單= new List<float>();
    //public LayerMask 圖層;
    /*
    public touchLocation(int newTouchId, GameObject newCircle)
    {
        touchId = newTouchId;
        circle = newCircle;
    }
    */
    public touchLocation(int newTouchId,GameObject circle,List<func> noteTrack)
    {
        if (本關音軌資料 == null)
        {
            Debug.Log("try load");
            本關音軌資料 = Resources.Load<StageRangeCreator>("四軌資料");
            Debug.Log(本關音軌資料.name);
            
            
            foreach (var 現在數值 in 本關音軌資料.L1)
            {
                左1清單.Add(現在數值);
            }

            foreach (float 現在數值 in 本關音軌資料.L2)
            {
                左2清單.Add(現在數值);
            }
            foreach (float 現在數值 in 本關音軌資料.R1)
            {
                右1清單.Add(現在數值);
            }
            foreach (float 現在數值 in 本關音軌資料.R2)
            {
                右2清單.Add(現在數值);
            }
            //順序很重要
            音軌範圍.Add(左1清單);//0
            音軌範圍.Add(左2清單);//1
            音軌範圍.Add(右1清單);//2
            音軌範圍.Add(右2清單);//3
        }
        GameObject temp;
        touchId = newTouchId;
        //Debug.Log("dd");
        if (registed == false)
        {
            //如果手指觸碰到打擊範圍內(設定觸控範圍1208)
            Vector3 v = Camera.main.ScreenToWorldPoint(Input.GetTouch(touchId).position);
            
            //音軌範圍[0][0]  第一個[0] = 左1軌道 第二個[0] = 左1軌道清單的數值_1222
            //右軌1
            if (v.x > 音軌範圍[2][0] && v.x <音軌範圍[2][1])
            {
                //右側方形觸控範圍
                Debug.Log("右1X");
                if (v.y >音軌範圍[2][3] && v.y < 音軌範圍[2][2])
                {
                    noteTrack[1].嘗試擊中音符();
                    Debug.Log("右1Y");
                }
            }
            //右軌2
            if (v.x > 音軌範圍[3][0] && v.x <音軌範圍[3][1])
            {
                //右側方形觸控範圍
                Debug.Log("右1X");
                if (v.y >音軌範圍[3][3] && v.y < 音軌範圍[3][2])
                {
                    noteTrack[3].嘗試擊中音符();
                    Debug.Log("右2Y");
                }
            }
            //左軌1
            if (v.x > 音軌範圍[0][0] && v.x < 音軌範圍[0][1])
            {
                Debug.Log("左1X");
                if (v.y > 音軌範圍[0][3] && v.y <音軌範圍[0][2])
                {
                    noteTrack[0].嘗試擊中音符();
                    Debug.Log("左1Y");
                }
            }
            //左軌2
            if (v.x > 音軌範圍[1][0] && v.x < 音軌範圍[1][1])
            {
                Debug.Log("左2X");
                if (v.y > 音軌範圍[1][3] && v.y <音軌範圍[1][2])
                {
                    noteTrack[2].嘗試擊中音符();
                    Debug.Log("左2Y");
                }
            }
            
            
            //circle.transform.position = new Vector3(v.x, v.y, 200);
            //circle.GetComponent<CircleCollider2D>().enabled = true;
            /*
            temp = circle.GetComponent<TouchCollider>().findObject();
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.GetTouch(touchId).position) + "pos");
            if (temp != false)
            {
                //temp.GetComponent<parseIDToNote>().parseFinger(touchId);
                switch (temp.gameObject.name)
                {
                    case "左軌1號":
                        Debug.Log("www");
                        //noteTrack[0].touchID = touchId;
                        noteTrack[0].嘗試擊中音符();
                        break;
                    case "右軌1號":
                        Debug.Log("aaa");
                        //noteTrack[1].touchID = touchId;
                        noteTrack[1].嘗試擊中音符();
                        break;
                    
                }
            }
            */
            
        }
    }

    
}
