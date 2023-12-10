using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


    public class multipeTouch : MonoBehaviour
    {
        public GameObject tempCircle;
        public GameObject circle;
        public List<touchLocation> touches = new List<touchLocation>();
        public List<func> noteTrack = new List<func>();
        
        //沒有使用了 public LayerMask 圖層;

        public void Start()
        {
            
        }

        void Update()
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                if (t.phase == TouchPhase.Began )
                {
                    //Debug.Log("touch began");
                    touches.Add(new touchLocation(t.fingerId,tempCircle,noteTrack));
                    //touches.Add(new touchLocation(t.fingerId, creatCircle(t)));
                }
                else if (t.phase == TouchPhase.Ended)
                {
                    //Debug.Log("touch end");
                    
                    touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                    //Destroy(thisTouch.circle);
                    touches.RemoveAt(touches.IndexOf(thisTouch));
                }
                else if (t.phase == TouchPhase.Moved)
                {
                    Debug.Log("touch moving");
                    touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                    //thisTouch.circle.transform.position = getTouchPosition(t.position);
                }
            }
        }
        //抓取處空位置1208
        Vector2 getTouchPosition(Vector2 touchPosition)
        {
            return GetComponent<Camera>()
                .ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
        }
        //生成打印出左右手ID_1208
        GameObject creatCircle(Touch t)
        {
            GameObject c = Instantiate(circle) as GameObject;
            c.name = "Touch" + t.fingerId;
            c.transform.position = getTouchPosition(t.position);
            return c;
        }

    }


