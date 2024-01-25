using UnityEngine;

public class Dev_MouseWorld : MonoBehaviour
{
    //抓取打擊範圍座標1225
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse Pos = " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
