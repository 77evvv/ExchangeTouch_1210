using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace TouchEvent_handler
{
public class EventDetect : MonoBehaviour

{
        public static float quickDoubleTabInterval = 0.15f;
        public static float lastTouchTime;//上一次點擊放開的時間
        private static float begainTime = 0f;//最初點擊時間
        private static float intervals;//間隔時間
        public static float holdingTime = 3;//按住多久才會達到滿的狀態

        private static Vector2 startPos = Vector2.zero;//觸碰起始點
        private static Vector2 endPos = Vector2.zero;//觸碰結束點
        private static Vector2 direction = Vector2.zero;//移動方向

        private static Touch lastTouch;//目前沒用到，不果主要是記錄上一次的觸碰

        public static string debugInfo = "Nothing";
      
        public Vector3 TouchDetect(float oldTime )
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                bool isTouchUIElement = EventSystem.current.IsPointerOverGameObject(touch.fingerId);
                
                if(isTouchUIElement && isTouchUIElement)
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began://點下去的狀態
                            startPos = touch.position;
                            begainTime = oldTime;
                            QuickDoubleTab(oldTime);
                            return Vector3.zero;
                            break;


                        case TouchPhase.Moved://手按住滑動的狀態
                            direction = touch.position - startPos;
                            intervals = oldTime - begainTime;
                            Hold();
                            break;


                        case TouchPhase.Ended://手離開螢幕時的狀態
                            intervals = oldTime - begainTime;
                            lastTouchTime = oldTime;
                            endPos = startPos + direction;
                            lastTouch = touch;
                            Swipe(intervals, direction);
                            break;

                        case TouchPhase.Stationary://手按住不動的狀態
                            intervals = oldTime - begainTime;
                            Hold();
                            return new Vector3(0, 0, -100);
                            break;

                    }  
                }
                return new Vector3(0, 0, -100);
            }

            return new Vector3(0, 0, -100);
        }
        //判斷雙擊事件是否成立，成立了以後要做什麼
        static void QuickDoubleTab(float timeBranch)
        {
            if(timeBranch - lastTouchTime < quickDoubleTabInterval)
            {
                debugInfo = "touchCount";
            }
        }
        //判斷快速滑動是否成立，成立了以後要做什麼
        static void Swipe(float intervalTime,Vector2 _direction)
        {
            if(intervalTime < 0.2f & _direction.magnitude > 120f)
            {
                debugInfo = "Swipe interval time : " + intervalTime + "Swipe direction : " + _direction;
            }
        }
        //判斷按住事件是否成立，成立了以後要做什麼
        static void Hold()
        {
            if(intervals > holdingTime)
            {
                debugInfo = "Hold MAX";
            }
            else if(intervals > 0.3f)
            {
                debugInfo = "Holding" + (intervals / holdingTime) * 100 + "%";
            }
           

        }
    }
}