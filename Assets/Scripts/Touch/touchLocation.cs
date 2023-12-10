using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class touchLocation
{
    public int touchId;
    //public GameObject circle;

    public bool registed;

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
        GameObject temp;
        touchId = newTouchId;
        //Debug.Log("dd");
        if (registed == false)
        {
            //如果手指觸碰到打擊範圍內(設定觸控範圍1208)
            Vector3 v = Camera.main.ScreenToWorldPoint(Input.GetTouch(touchId).position);
            if (v.x > 2.63f && v.x <5.45f)
            {
                //右側方形觸控範圍
                Debug.Log("右X");
                if (v.y >-3.64f && v.y < -0.90f)
                {
                    noteTrack[1].嘗試擊中音符();
                    Debug.Log("右Y");
                }
            }
            //左側方形觸控範圍
            if (v.x > -5.43f && v.x < -2.65f)
            {
                Debug.Log("左X");
                if (v.y > -3.86f && v.y <-0.90f)
                {
                    noteTrack[0].嘗試擊中音符();
                    Debug.Log("左Y");
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
