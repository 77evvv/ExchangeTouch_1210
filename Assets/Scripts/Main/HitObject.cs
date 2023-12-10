using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PathCreation;
using PathCreation.Examples;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

    public class HitObject : MonoBehaviour
    {
        public int touchID;
        public touch myTouch;
        public GameMain scoreShower;
        public enum 軌道判斷
        {
            左軌內,
            左軌外,
            右軌內,
            右軌外
            
        }
        public enum developerMode
        {
            不讀檔,
            電腦,
            android
        }

        public developerMode 遊戲運行平台;

        public enum callJson
        {
            待機,
            呼叫存檔,
            呼叫讀檔
        }

        public enum 音符生成
        {
            音量生成,
            所有音符已生成完,
            讀取檔案生成,
        }

        public enum 圖片方向
        {
            左,
            右,
        }


        public 圖片方向 圖片面向方向;

        public 軌道判斷 軌道;
        //0=點擊 1=滑動 2=長按
        public Sprite[] 左側音符;
        public Sprite[] 右側音符;
        public string android檔案名子;
        public PathCreator 離開路徑;
        public PathCreator 音符路徑右;
        public float 聲音抓取;
        public float 音符多快到點;
        public float 音符時差;
        public DOTweenAnimation ab; 
        
        public float 經過時間;
        public int 當前音符;
        public 音符生成 音符產生方式;
        public string 檔案名字;
        public callJson Json狀態;
        public string 存檔路徑;
        
        public GameObject objectPrefab;
        public float threshold = 21f;
        public float BPM;
        public float SecPerBeat;
        public float waitTime;
        private AudioSource audioSource;
        
        public float t;
        public float[] ttime;
        public int i;
        public List<float> song = new List<float>();
        public List<int> 音符總類 = new List<int>();
        public Text debugText;
        public int number;
        public int debugBool;
        public UserData 讀取檔案 = null;
        //新增生成音符替身以降低效能1208
        public func 替身;
        void Start()
        {
            //Debug.Log(軌道.ToString());
            debugText.text = number.ToString();
            audioSource = GetComponent<AudioSource>();
            SecPerBeat = 60f / BPM;
            t = Time.time;
            i = 0;
            //ttime[i] = t;
            if (音符產生方式 == 音符生成.讀取檔案生成)
            {

                if (遊戲運行平台 == developerMode.android)
                {
                    // 此串更新JSON檔可以成功在模擬器上生成音符
                    Debug.Log("1111");
                    debugText.text = "抓檔案";
                    debugText.text = "檔案";
                    //var jsonTextFile = Resources.Load<Texture2D>(android檔案名子);
                    // 之後要手動JSON檔名改為.txt
                    var jsonTextFile = Resources.Load<TextAsset>(android檔案名子);
                    if (jsonTextFile == null)
                    {
                        debugText.text = "無檔案";
                    }
                    else
                    {
                        debugText.text = "有抓到";
                    }

                    String json = jsonTextFile.text;
                    debugText.text = "aaaa";
                    讀取檔案 = JsonUtility.FromJson<UserData>(json);
                    debugText.text = "有檔案";
                }
                else if (遊戲運行平台 == developerMode.電腦)
                {
                    讀取檔案 = JsonWrite.LoadJson(Application.dataPath + 存檔路徑 + 檔案名字);
                }

                Debug.Log(讀取檔案);
                if (讀取檔案 == null)
                {
                    //debugText.text = "沒檔案";
                    debugBool = -1;
                    Debug.Log("2222");
                }

                song = 讀取檔案.moments;
                音符總類 = 讀取檔案.noteType;
                經過時間 = 0;
                當前音符 = 0;
            }
        }

        
        private void FixedUpdate()
        {
            if (音符產生方式 == 音符生成.音量生成 && audioSource != null && audioSource.isPlaying && waitTime >= SecPerBeat)
            {

                // 獲取音量值
                float volume = GetAverageVolume() * 聲音抓取;
                //Debug.Log("normal + "+volume);
                // 如果音量超過閾值，創建一個新物體
                if (volume > threshold)
                {
                    waitTime = 0;
                    //Debug.Log("spawn + "+volume);
                    i++;
                    t = Time.time;
                    //ADD TIME
                    song.Add(t);
                    音符總類.Add(0);
                    Debug.Log("T" + t);
                    GameObject aa = Instantiate(objectPrefab, transform.position, transform.rotation);


                }
            }

            if (音符產生方式 == 音符生成.讀取檔案生成 && debugBool != -1)
            {
                經過時間 += Time.deltaTime;

                if (經過時間 >= song[當前音符] - 音符時差)
                {
                    number++;
                    debugText.text = number.ToString();
                    //Debug.Log("生成音符");
                    GameObject note = Instantiate(objectPrefab, transform.position, transform.rotation);
                    if ((圖片面向方向 == 圖片方向.左))
                    {

                        note.GetComponent<SpriteRenderer>().sprite = 左側音符[音符總類[當前音符]];
                    }
                    else if (圖片面向方向 == 圖片方向.右)
                    {
                        note.GetComponent<SpriteRenderer>().sprite = 右側音符[音符總類[當前音符]];
                    }

                    //GameObject note2 = Instantiate(objectPrefab, transform.position, transform.rotation);
                    Move mScript = note.GetComponent<Move>();
                    mScript.音符編號 = number;
                    mScript.本地音符路徑 = 音符路徑右;
                    mScript.pathOverTime = 音符多快到點;
                    mScript.本地離開路徑 = 離開路徑;
                    //把軌道分軌+顯示分數
                    mScript.軌道Assign(軌道.ToString());
                    mScript.scoreShower = scoreShower;
                    mScript.HitObject = this;
                    mScript.myTouch = myTouch;
                    //設定替身以降低效能1208
                    替身.myNote.Add(mScript);
                    mScript.替身 = 替身;
                    當前音符++;
                }

                if (當前音符 >= song.Count)
                {
                    音符產生方式 = 音符生成.所有音符已生成完;
                    Debug.Log("結束生成");
                    return;
                }
            }
        }

        void Update()
        {
            
            if (waitTime <= SecPerBeat)
            {
                waitTime += Time.deltaTime;

            }
            
            if (Json狀態 == callJson.呼叫存檔)
            {
                Json狀態 = callJson.待機;
                UserData data = new UserData
                {
                    moments = song,
                    noteType = 音符總類,
                };
                Debug.Log("傳送資料");
                //接收資料
                JsonWrite.WritingJson(data, Application.dataPath + 存檔路徑 + 檔案名字);

            }

            if (Json狀態 == callJson.呼叫讀檔)
            {
                Json狀態 = callJson.待機;
            }

        }

        // 獲取平均音量值
        float GetAverageVolume()
        {
            float[] samples = new float[256];
            audioSource.GetOutputData(samples, 0);

            float sum = 1f;
            for (int i = 0; i < samples.Length; i++)
            {
                sum += Mathf.Abs(samples[i]);
            }

            return sum / samples.Length;
        }
    }
