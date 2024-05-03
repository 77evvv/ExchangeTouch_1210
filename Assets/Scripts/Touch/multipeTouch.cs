using System.Collections.Generic;
using UnityEngine;


public class multipeTouch : MonoBehaviour
    {
        public GameObject tempCircle;
        public GameObject circle;
        public List<touchLocation> touches = new List<touchLocation>();
        public List<func> noteTrack = new List<func>();
        
        public float swipeThreshold = 200f; // 滑动阈值
        private Vector2 initialTouchPos; // 初始触摸位置
        public TouchSharedValue[] touchValue;
        
        [System.Serializable]
        public class TouchSharedValue
        {
            
            public bool fakeSwipe;
            public Vector2 initialTouchPos;
        }
        //沒有使用了 public LayerMask 圖層;

        void Start()
        {
            
        }
        
        void Update()
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                if (t.phase == TouchPhase.Began)
                {
                    touchValue[i].fakeSwipe = false;
                    touchValue[i].initialTouchPos = t.position;
                    Debug.Log("touch began");
                    touches.Add(new touchLocation(t.fingerId, tempCircle, noteTrack,0));
                    //touches.Add(new touchLocation(t.fingerId, creatCircle(t)));
                }
                else if (t.phase == TouchPhase.Ended)
                {
                    //Debug.Log("touch end");
                    
                    touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                    
                    //Destroy(thisTouch.circle);
                    touches.RemoveAt(touches.IndexOf(thisTouch));
                    touchValue[i].fakeSwipe = false;
                }
                else if (t.phase == TouchPhase.Moved)
                {
                    
                    Vector2 currentTouchPos = t.position;
                    float swipeDistance = currentTouchPos.x - touchValue[i].initialTouchPos.x;
                    
                    // 判断左滑或右滑
                    if (Mathf.Abs(swipeDistance) > swipeThreshold && touchValue[i].fakeSwipe == false)
                    {
                        //Debug.Log($"距離 = {swipeDistance}");
                        touchValue[i].fakeSwipe = true;
                        if (swipeDistance > 0)
                        {
                            touches.Add(new touchLocation(t.fingerId, tempCircle, noteTrack,1));
                            touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                            
                            Debug.Log("Right Swipe");
                            touches.RemoveAt(touches.IndexOf(thisTouch));
                            // 执行右滑操作，例如触发角色状态改变等
                        }
                        else
                        {
                            touches.Add(new touchLocation(t.fingerId, tempCircle, noteTrack,2));
                            touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                            
                            Debug.Log("Left Swipe");
                            touches.RemoveAt(touches.IndexOf(thisTouch));
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


