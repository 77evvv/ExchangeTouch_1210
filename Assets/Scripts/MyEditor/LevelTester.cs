using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

[ExecuteInEditMode]
public class LevelTester : MonoBehaviour
{
    [Header("開發者物件")] public Texture2D[] icon;
    public int number = 0;

    [Header("關卡物件")] public GameObject notePrefab;
    
    public GameMain scoreShower;
    public 存檔組[] 關卡音軌檔案;
    public 圖片組[] 關卡音符圖種;
    public 路徑組[] 關卡路徑組;
    [System.Serializable]
    public class 路徑組
    {
        public string 路徑名;
        public PathCreator 離開路徑;
        public PathCreator 音符路徑;
        public func pathFunc;
    }
    [System.Serializable]
    public class 圖片組
    {
        public string 圖片名;
        public Sprite 左Sprite;
        public Sprite 右Sprite;
    }
    [System.Serializable]
    public class 存檔組
    {
        public string 關卡名;
        public TextAsset 左1存檔;
        public TextAsset 左2存檔;
        public TextAsset 右1存檔;
        public TextAsset 右2存檔;
    }
    [Header("背景")] public GameObject[] 關卡背景;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void d_ChangeBG(int index)
    {
        foreach (var VARIABLE in 關卡背景)
        {
            VARIABLE.SetActive(false);
        }
        關卡背景[index].SetActive(true);
    }

    public void d_SpawnNote(int noteType,int noteDir,int notePath,int noteSlideDir)
    {
        #region 生成音符
        GameObject note = Instantiate(notePrefab, transform.position, transform.rotation);
        Move mScript = note.GetComponent<Move>();
        #endregion

        #region 方向與種類

        switch (noteDir)
        {
            case 0:
                note.GetComponent<SpriteRenderer>().sprite = 關卡音符圖種[noteType].左Sprite;
                break;
            case 1:
                note.GetComponent<SpriteRenderer>().sprite = 關卡音符圖種[noteType].右Sprite;
                break;
        }
        #endregion
        #region 路徑
        
        mScript.音符編號 = number;
        number++;
        關卡路徑組[notePath].pathFunc.myNote.Add(mScript);
        mScript.替身 = 關卡路徑組[notePath].pathFunc;
        mScript.本地音符路徑 = 關卡路徑組[notePath].音符路徑;
        mScript.pathOverTime = 1.32f;
        mScript.scoreShower = scoreShower;
        mScript.本地離開路徑 = 關卡路徑組[notePath].離開路徑;
        

        #endregion
        #region 種類
        //滑動    
        if (noteType ==1)
        {
            switch (noteSlideDir)
            {
                case 0:
                    mScript.SetNoteType(2);
                    break;
                case 1:
                    mScript.SetNoteType(1);
                    break;
            }
        }
        else
        {
            if (noteType == 2)
            {
                Debug.Log("SetUp");
                mScript.SetUpLine();
            }
            else
            {
                mScript.SetNoteType(0);
            }
            
        }
        

        #endregion
        
        
        
    }
}
