using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using DG.Tweening;

namespace PathCreation.Examples
{
    public class Move : MonoBehaviour
    {
        public SpriteRenderer sr;
        //創建替身以降低效能
        public func 替身;
        public HitObject HitObject;
        public float[] 判分範圍;
        public enum 軌道判斷
        {
            左軌內,
            左軌外,
            右軌內,
            右軌外
            
        }
        
        public touch myTouch;
        public 軌道判斷 軌道;
        public int 音符編號;
        

        public int scoreT;

        public int now; //現在的狀況，0=miss 1=bad 2=nice 3=perfect
        //設置音符曲線
        public PathCreator 本地音符路徑;
        public EndOfPathInstruction endOfPathInstruction;

        public DOTweenPath 音符曲線;

        //public DOTweenPath 音符路徑;
        
        public float pathSpeed;

        public float pathOverTime;
        //音符離開曲線
        public PathCreator 本地離開路徑;
        //設定音符狀態
        public enum pathState
        {
            入場,切換路徑,離開
        }
        //音符從小變大漸變
        public Vector3 起始大小 = new Vector3(0.1f,0.1f,0.1f);
        public Vector3 最終大小 = new Vector3(1,1,1);
        public pathState 音符移動狀態;
    //抓GM
    private GameObject GM;
    public GameMain scoreShower;

    //public Transform spawnPoint;
    //private bool isScaling = true;

    private Vector3 startScale;
    float distanceTravelled;
    public float 進度;
    [SerializeField]
    private float 總體時間;
    [SerializeField]
    private float 經過時間;

    public bool deleteSelf;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //Debug.Log(軌道.ToString());
        經過時間 = 0;
        總體時間 = pathOverTime;
        pathSpeed = 本地音符路徑.path.length / pathOverTime;
        distanceTravelled = 0;
        //開始
        startScale = transform.localScale;
        transform.localScale = startScale / 3f;
        GM = GameObject.FindGameObjectWithTag("GM");
        
        //Debug.Log(GM.name);
    }

    // Update is called once per frame
    void Update()
    {
        //判定音符該入場時間
        if (本地音符路徑 != null && 音符移動狀態 == pathState.入場)
       {
           distanceTravelled += pathSpeed * Time.deltaTime;
           
           if (經過時間 > 總體時間)
           {
               經過時間 = 總體時間;
           }
           else
           {
               經過時間 += Time.deltaTime;
           }
           //設定音符漸變大小
           transform.localScale = new Vector3(Mathf.Lerp(起始大小.x,最終大小.x,(經過時間/總體時間)),Mathf.Lerp(起始大小.y,最終大小.y,(經過時間/總體時間)),1);
           transform.position = 本地音符路徑.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
           進度 = distanceTravelled / 本地音符路徑.path.length;
           if (transform.position == 本地音符路徑.path.GetPoint(本地音符路徑.path.NumPoints - 1))
           {
               音符移動狀態 = pathState.離開;
               distanceTravelled = 0;
           }
       }
        //接換離開路徑
       if (音符移動狀態 == pathState.離開)
       {
           distanceTravelled += pathSpeed * Time.deltaTime;
           transform.position = 本地離開路徑.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
           進度 = distanceTravelled / 本地離開路徑.path.length;
           if (transform.position == 本地離開路徑.path.GetPoint(本地離開路徑.path.NumPoints - 1))
           {
               Destroy(this.gameObject);
               //這邊MISS要加+1
           }
       }

       
       if (音符移動狀態 == pathState.離開)
       {
           if (進度 > 判分範圍[5] && deleteSelf == false)
           {
               //離開判定區就變色1208更新
               sr.color = Color.red;
               deleteSelf = true;
               //miss
               替身.myNote.RemoveAt(0);
           }
       }
       
        //可滑動拉!!!!!!!!判定位子消除音符**之後改
        Vector3 Lv = new Vector3(-1, 0, 0);
        Vector3 Rv = new Vector3(1, 0, 0);
        Vector3 Sv = new Vector3(0, 0, 0);
        return;
        if (HitObject.touchID < 0)
        {
            return;
        }
        //這次增加判定分數1031
        if ( Input.GetTouch(HitObject.touchID).phase == TouchPhase.Began  && 軌道.ToString() == myTouch.軌道.ToString() )
        {
            if (音符移動狀態 == pathState.入場)
            {
                if (進度 < 判分範圍[0] && 進度 > 判分範圍[6])
                {
                    //Bad
                    scoreShower.showScore(0);
                    SpriteHitPic.spriteName = "Bad";
                    Destroy(gameObject);
                }
                if (進度 >= 判分範圍[0] && 進度 <= 判分範圍[1])
                {
                    //nice
                    scoreShower.showScore(1);
                    SpriteHitPic.spriteName = "Nice";
                    Destroy(gameObject);
                }
                if (進度 > 判分範圍[1] && 進度 <= 判分範圍[2])
                {
                    //perfect
                    scoreShower.showScore(2);
                    SpriteHitPic.spriteName = "Perfect";
                    Destroy(gameObject);
                }
                
            }
            else if (音符移動狀態 == pathState.離開)
            {
                if (進度 >= 0 && 進度 <= 判分範圍[3])
                {
                    //perfect
                    scoreShower.showScore(2);
                    SpriteHitPic.spriteName = "Perfect";
                    Destroy(gameObject);
                }
                if (進度 > 判分範圍[3] && 進度 <= 判分範圍[4])
                {
                    //Nice
                    scoreShower.showScore(1);
                    SpriteHitPic.spriteName = "Nice";
                    Destroy(gameObject);
                }
                if (進度 > 判分範圍[4] && 進度 <= 判分範圍[5])
                {
                    //bad
                    scoreShower.showScore(0);
                    SpriteHitPic.spriteName = "Bad";
                    Destroy(gameObject);
                }

                if (進度 > 判分範圍[5])
                {
                    //miss
                }
            }
        }
        
    }
    //新增替身降低耗能1208更新
    public void detectNote()
    {
        if (音符移動狀態 == pathState.入場)
        {
            if (進度 < 判分範圍[0] && 進度 > 判分範圍[6])
            {
                //Bad
                scoreShower.showScore(0);
                SpriteHitPic.spriteName = "Bad";
                替身.myNote.RemoveAt(0);
                Destroy(gameObject);
            }
            if (進度 >= 判分範圍[0] && 進度 <= 判分範圍[1])
            {
                //nice
                scoreShower.showScore(1);
                SpriteHitPic.spriteName = "Nice";
                替身.myNote.RemoveAt(0);
                Destroy(gameObject);
            }
            if (進度 > 判分範圍[1] && 進度 <= 判分範圍[2])
            {
                //perfect
                scoreShower.showScore(2);
                SpriteHitPic.spriteName = "Perfect";
                替身.myNote.RemoveAt(0);
                Destroy(gameObject);
            }
                
        }
        else if (音符移動狀態 == pathState.離開)
        {
            if (進度 >= 0 && 進度 <= 判分範圍[3])
            {
                //perfect
                scoreShower.showScore(2);
                SpriteHitPic.spriteName = "Perfect";
                替身.myNote.RemoveAt(0);
                Destroy(gameObject);
            }
            if (進度 > 判分範圍[3] && 進度 <= 判分範圍[4])
            {
                //Nice
                scoreShower.showScore(1);
                SpriteHitPic.spriteName = "Nice";
                替身.myNote.RemoveAt(0);
                Destroy(gameObject);
            }
            if (進度 > 判分範圍[4] && 進度 <= 判分範圍[5])
            {
                //bad
                scoreShower.showScore(0);
                SpriteHitPic.spriteName = "Bad";
                替身.myNote.RemoveAt(0);
                Destroy(gameObject);
            }

            if (進度 > 判分範圍[5])
            {
                替身.myNote.RemoveAt(0);
                //miss
            }
        }
    }
    void Obj()
    {
        //分別
    }

    public void 軌道Assign(string aa)
    {
        switch (aa)
        {
            case "左軌內" :
                軌道 = 軌道判斷.左軌內;
                break;
            case "右軌內" :
                軌道 = 軌道判斷.右軌內;
                break;
            case "左軌外" :
                軌道 = 軌道判斷.左軌外;
                break;
            case "右軌外" :
                軌道 = 軌道判斷.右軌外;
                break;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Edge")
        {
            GM.GetComponent<GameMain>().gameHit.Add(now);
            Destroy(gameObject);
            //Debug.Log("Edge");
        }
    }
}
}
