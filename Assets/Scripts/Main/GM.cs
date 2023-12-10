using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
//此Test檔案在程式裡可以更清楚更改圖片+知道哪幾個圖片變換
public class GM : MonoBehaviour
{
    public GameObject holder;
    public callJson Json狀態;

    public string 左軌檔案名字;
    public string 右軌檔案名字;
    public string 存檔路徑;
    public List<float> 左音符生成時間;
    public List<int> 左音符生成種類;
    public List<float> 右音符生成時間;
    public List<int> 右音符生成種類;
    [Header("編輯器數值")]
    public float 音符的間隔;
    public Sprite[] 圖片種類;

    public TextAsset 左音軌來源;
    public TextAsset 右音軌來源;
    public UserData 左軌檔案;
    public UserData 右軌檔案;
    public GameObject EmptyNote;

    public LineRenderer 左音軌線;
    public LineRenderer 右音軌線;
    public enum 更新音符
    {
     待機,
     更新,
    }
    public enum callJson
    {
        待機,
        呼叫存檔,
        呼叫讀檔
    }

    public 更新音符 音符狀態;
    // Start is called before the first frame update
    void Start()
    {
        string a = 左音軌來源.ToString();
        左軌檔案 = JsonConvert.DeserializeObject<UserData>(a);
        左音符生成種類 = 左軌檔案.noteType;
        左音符生成時間 = 左軌檔案.moments;
        string b = 右音軌來源.ToString();
        右軌檔案 = JsonConvert.DeserializeObject<UserData>(b);
        右音符生成種類 = 右軌檔案.noteType;
        右音符生成時間 = 右軌檔案.moments;
    }

    // Update is called once per frame
    void Update()
    {
        if (音符狀態 == 更新音符.更新)
        {
            foreach (Transform child in holder.transform)
            {
                Destroy(child.gameObject);
            }
            音符狀態 = 更新音符.待機;
            左音軌線.SetPosition(1, new Vector3(音符的間隔 * 左音符生成時間[左音符生成時間.Count-1],0,0));
            右音軌線.SetPosition(1, new Vector3(音符的間隔 * 右音符生成時間[右音符生成時間.Count-1],0,0));
            for (int i = 0; i < 左音符生成時間.Count; i++)
            {
                GameObject a = Instantiate(EmptyNote);
                a.transform.parent = holder.transform;
                a.transform.position = new Vector3(音符的間隔 * 左音符生成時間[i], 5, 0);
                a.GetComponent<Image>().sprite = 圖片種類[左音符生成種類[i]];
                a.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                Text b = a.transform.GetChild(0).GetComponent<Text>();
                b.text = i.ToString();
            }
            for (int i = 0; i < 右音符生成時間.Count; i++)
            {
                GameObject a = Instantiate(EmptyNote);
                a.transform.parent = holder.transform;
                a.transform.position = new Vector3(音符的間隔 * 右音符生成時間[i], -5, 0);
                a.GetComponent<Image>().sprite = 圖片種類[右音符生成種類[i]];
                a.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                Text b = a.transform.GetChild(0).GetComponent<Text>();
                b.text = i.ToString();
            }
        }
        if (Json狀態 == callJson.呼叫存檔)
        {
            Json狀態 = callJson.待機;
            UserData data = new UserData
            {
                moments = 左音符生成時間,
                noteType = 左音符生成種類,
            };
            Debug.Log("傳送資料");
            //接收資料
            JsonWrite.WritingJson(data, Application.dataPath +存檔路徑+ 左軌檔案名字);

            data = new UserData()
            {
                moments = 右音符生成時間,
                noteType = 右音符生成種類,
            };
            Debug.Log("傳送資料");
            //接收資料
            JsonWrite.WritingJson(data, Application.dataPath +存檔路徑+ 右軌檔案名字);
        }
        
        if (Json狀態 == callJson.呼叫讀檔)
        {
            Json狀態 = callJson.待機;
        }
    }
}
