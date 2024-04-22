using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POSIONBOX : MonoBehaviour
{
    public Transform squareTransform; // 正方形的 Transform 組件
    public float squareSize = 1f; // 正方形的尺寸

    void Update()
    {
        // 檢查滑鼠左鍵是否按下
        if (Input.GetMouseButtonDown(0))
        {
            // 獲取滑鼠點擊的位置
            Vector3 clickPosition = Input.mousePosition;
            clickPosition.z = Camera.main.nearClipPlane; // 設置 z 軸位置為攝像機的 nearClipPlane

            // 將屏幕空間的點轉換為世界空間點
            Vector3 worldClickPosition = Camera.main.ScreenToWorldPoint(clickPosition);

            // 獲取正方形中心點的世界空間座標
            Vector3 squareCenter = squareTransform.position;

            // 計算最接近正方形邊緣的座標
            float halfSize = squareSize / 2f;
            float x = Mathf.Clamp(worldClickPosition.x, squareCenter.x - halfSize, squareCenter.x + halfSize);
            float y = Mathf.Clamp(worldClickPosition.y, squareCenter.y - halfSize, squareCenter.y + halfSize);

            // DEBUG 輸出最接近邊緣的座標
            Debug.Log("Clicked Position: " + new Vector2(x, y));
        }
    }
}