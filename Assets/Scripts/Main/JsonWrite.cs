using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;


public class JsonWrite : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    void Start()
    {
        List<string> moments = new List<string>();
        //這邊應該要加入第一首歌的每一個產生點 HOW?
        moments.Add("music");

        UserData newData = new UserData
        {
            //T = Time.time,  // Assuming you want to store the current time
            moments = moments
        };

        
        string jsonInfo = JsonConvert.SerializeObject(newData);
        File.WriteAllText("C:/TraceBack0530/Assets/file1", jsonInfo);
        Debug.Log("file1寫入完成");

    }
    */
    //接收資料及存檔路徑
    public static void WritingJson(UserData newData,string path)
    {
        Debug.Log("接收資料嘗試存檔");
        string jsonInfo = JsonUtility.ToJson(newData,true);
        //"Assets/file1"
        Debug.Log("嘗試收尋存檔路徑");
        File.WriteAllText(path, jsonInfo);
        Debug.Log("存檔成功");
    }
    public static UserData LoadJson(string path)
    {
        string loadData = File.ReadAllText(path);
        UserData outPutData;
        Debug.Log("Loading");

        outPutData = JsonConvert.DeserializeObject<UserData>(loadData);
        return outPutData;
    }

// Update is called once per frame
    void Update()
    {
    }

    public class music
    {
        public string eMoment;
    }

   
}
public class UserData
{
    //public float T;
    public List<float> moments;
    public List<int> noteType;
}