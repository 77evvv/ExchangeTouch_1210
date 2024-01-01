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
        
        private const float swipeThreshold = 150f; // 滑动阈值
        private Vector2 initialTouchPos; // 初始触摸位置
        
        
        //沒有使用了 public LayerMask 圖層;

        public void Start()
        {
            
        }

        void Update()
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                if (t.phase == TouchPhase.Began)
                {
                    //Debug.Log("touch began");
                    touches.Add(new touchLocation(t.fingerId, tempCircle, noteTrack));
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
                    Vector2 currentTouchPos = t.position;
                    float swipeDistance = currentTouchPos.x - initialTouchPos.x;

                    // 判断左滑或右滑
                    if (Mathf.Abs(swipeDistance) > swipeThreshold)
                    {
                        if (swipeDistance > 0)
                        {
                            Debug.Log("Right Swipe");
                            // 执行右滑操作，例如触发角色状态改变等
                        }
                        else
                        {
                            Debug.Log("Left Swipe");
                            // 执行左滑操作，例如触发角色状态改变等
                        }
                    }
                }
                
            }
        }

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


