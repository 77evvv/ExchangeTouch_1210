using System.Collections;
using System.Collections.Generic;
using TouchEvent_handler;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static TouchEvent_handler.EventDetect;
using UnityEngine.SceneManagement;

public class touch : MonoBehaviour
{
    public enum 軌道判斷
    {
        左軌內,
        左軌外,
        右軌內,
        右軌外
            
    }

    public EventDetect ed;
    public  軌道判斷 軌道;
    //private static float begainTime = 0f;//最初點擊時間
    private static float intervals; //間隔時間
    public static float holdingTime = 3; //按住多久才會達到滿的狀態
    private static Vector2 startPos = Vector2.zero; //觸碰起始點
    private static Vector2 endPos = Vector2.zero; //觸碰結束點
    private static Vector2 direction = Vector2.zero; //移動方向
    private Animator playerAnim;//Ewan的動作切換


    public Text txt;
    public Text uniTime, LastTouchText, Calculation, allowValue;
    public Text dirText;

    public Text memberText;
    public int member;
    

    //private bool canDestroy = false;
    public  Vector3 newDir;
    //改變Player的Anim動作要先抓取Player的GameObject
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
        //抓取Player的Anim
        //playerAnim = player.GetComponent<Animator>();
    }

    // Update is called once per frame

    //我想要點擊一下就可以消除飄來的TAG ARROW
    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Update the Text on the screen depending on current position of the touch each frame
            //m_Text.text = "Touch Position : " + touch.position;
            txt.text = debugInfo;
            uniTime.text = "time since start " + Time.realtimeSinceStartup.ToString();
            LastTouchText.text = "last time i touch " + lastTouchTime;
            Calculation.text = "result = " + (Time.realtimeSinceStartup - lastTouchTime).ToString();
            allowValue.text = " allowValue = " + quickDoubleTabInterval;
            dirText.text = newDir.ToString();
            if (Time.realtimeSinceStartup - lastTouchTime < quickDoubleTabInterval)
            {
                //雙擊
                //DestroyArrow();
            }
            else
            {
                //m_Text.text = "No touch contacts";
            }
        }
        //一開始最左邊的音符會被削掉是因為0.0.0，加這行是不讓音符削掉+產生紅字
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            newDir = new Vector3(0, 0, -100);
            return;
        }

        if (EventSystem.current.currentSelectedGameObject == this.gameObject)
        {
            newDir = ed.TouchDetect(Time.realtimeSinceStartup);
        }
        
        if (newDir.z < -99)
        {
            return;
        }
        if (newDir.x < 0)
        {
            newDir = new Vector3(-1, 0, 0);
            {
                //playerAnim.SetBool("Hit", false);
                //滑動時撥放Swipe
                //playerAnim.SetBool("Swipe", true);
            }
        }
        else if (newDir.x > 0)
        {
            newDir = new Vector3(1, 0, 0);
            //playerAnim.SetBool("Hit", false);
            //playerAnim.SetBool("Swipe", true);
        }
        else
        {
            newDir = new Vector3(0, 0, 0);
            //playerAnim.SetBool("Hit", true);
            //playerAnim.SetBool("Swipe", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //物件是否有碰到我的打擊點
    {
        if (other.tag == "Arrow")
        {
            member++;
            //memberText.text = member.ToString();
            //Debug.Log("有碰到");
           
        }
    }

  
    

    /*假如音符碰到打擊點，我才能在範圍裏按下去，我才能打擊到物件*/

}