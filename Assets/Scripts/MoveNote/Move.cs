using UnityEngine;
using DG.Tweening;

namespace PathCreation.Examples
{
    public class Move : MonoBehaviour
    {
        public GameObject partical;

        public SpriteRenderer sr;
        public Animator EwanAni;

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
            入場,
            切換路徑,
            離開
        }

        //音符從小變大漸變
        public Vector3 起始大小 = new Vector3(0.1f, 0.1f, 0.1f);
        public Vector3 最終大小 = new Vector3(1, 1, 1);

        public pathState 音符移動狀態;

        //抓GM
        private GameObject GM;
        public GameMain scoreShower;

        //public Transform spawnPoint;
        //private bool isScaling = true;

        private Vector3 startScale;
        float distanceTravelled;
        public float 進度;
        [SerializeField] private float 總體時間;
        [SerializeField] private float 經過時間;

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
            EwanAni = GameObject.Find("EwanPlay").GetComponent<Animator>();

            //Debug.Log(GM.name);
        }

        //1222特效Boom_show
        public void 顯示特效(int 呼叫動畫)
        {
            if (呼叫動畫 != 2)
            {
                partical.SetActive(true);
                //讓特效離開音符
                partical.transform.parent = null;
            }
            //0102增加Ewan_Animator
            AnimatorClipInfo[] ac = EwanAni.GetCurrentAnimatorClipInfo(0);
            if (ac[0].clip.name == "Ewan_Hit")
            {
                
            }
            else
            {
                switch (呼叫動畫)
                {
                    case 0 :
                        EwanAni.Play("Ewan_Hit");
                        break;
                    case 1:
                        EwanAni.Play("Ewan_Bad");
                        break;
                    case 2:
                        EwanAni.Play("Ewan_miss");
                        break;
                }
            }
            
            
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
                transform.localScale = new Vector3(Mathf.Lerp(起始大小.x, 最終大小.x, (經過時間 / 總體時間)),
                    Mathf.Lerp(起始大小.y, 最終大小.y, (經過時間 / 總體時間)), 1);
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
                    sr.color = Color.gray;
                    deleteSelf = true;
                    //MISS判定+動畫播放改到這_0102
                    scoreShower.showScore(3);
                    SpriteHitPic.spriteName = "Miss";
                    顯示特效(2);
                    //miss
                    替身.myNote.RemoveAt(0);
                }
            }

            //可滑動拉!!!!!!!!判定位子消除音符**之後改
            Vector3 Lv = new Vector3(-1, 0, 0);
            Vector3 Rv = new Vector3(1, 0, 0);
            Vector3 Sv = new Vector3(0, 0, 0);
            return;
            

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
                    顯示特效(1);
                    Destroy(gameObject);
                }

                if (進度 >= 判分範圍[0] && 進度 <= 判分範圍[1])
                {
                    //nice
                    scoreShower.showScore(1);
                    SpriteHitPic.spriteName = "Nice";
                    替身.myNote.RemoveAt(0);
                    顯示特效(0);
                    Destroy(gameObject);
                    Debug.Log("Yes1");
                }


                if (進度 > 判分範圍[1] && 進度 <= 判分範圍[2])
                {
                    //perfect
                    scoreShower.showScore(2);
                    SpriteHitPic.spriteName = "Perfect";
                    替身.myNote.RemoveAt(0);
                    顯示特效(0);
                    Destroy(gameObject);
                    Debug.Log("Yes2");
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
                    顯示特效(0);
                    Destroy(gameObject);
                    Debug.Log("Yes3");
                }

                if (進度 > 判分範圍[3] && 進度 <= 判分範圍[4])
                {
                    //Nice
                    scoreShower.showScore(1);
                    SpriteHitPic.spriteName = "Nice";
                    替身.myNote.RemoveAt(0);
                    顯示特效(0);
                    Destroy(gameObject);
                    Debug.Log("Yes4");
                }


                if (進度 > 判分範圍[4] && 進度 <= 判分範圍[5])
                {
                    //bad
                    scoreShower.showScore(0);
                    SpriteHitPic.spriteName = "Bad";
                    替身.myNote.RemoveAt(0);
                    顯示特效(1);
                    Destroy(gameObject);
                    Debug.Log("Yes5");
                }


                if (進度 > 判分範圍[5])
                {
                    替身.myNote.RemoveAt(0);
                    SpriteHitPic.spriteName = "Miss";
                }
            }
        }
    

    public void 軌道Assign(string aa)
        {
            switch (aa)
            {
                case "左軌內":
                    軌道 = 軌道判斷.左軌內;
                    break;
                case "右軌內":
                    軌道 = 軌道判斷.右軌內;
                    break;
                case "左軌外":
                    軌道 = 軌道判斷.左軌外;
                    break;
                case "右軌外":
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
