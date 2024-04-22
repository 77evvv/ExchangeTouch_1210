using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GBJ : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject squareObject; // 正方形 GameObject

    void Start()
    {
        // 获取正方形 GameObject 的 RectTransform 组件
        RectTransform rectTransform = squareObject.GetComponent<RectTransform>();
        
        if (rectTransform != null)
        {
            // 获取正方形左下角的坐标（XY坐标）
            Vector2 bottomLeft = rectTransform.position - new Vector3(rectTransform.rect.width / 2f, rectTransform.rect.height / 2f);
            Debug.Log("Bottom Left Corner: " + bottomLeft);

            // 获取正方形右上角的坐标（XY坐标）
            Vector2 topRight = rectTransform.position + new Vector3(rectTransform.rect.width / 2f, rectTransform.rect.height / 2f);
            Debug.Log("Top Right Corner: " + topRight);

            // 获取正方形左上角的坐标（XY坐标）
            Vector2 topLeft = rectTransform.position + new Vector3(-rectTransform.rect.width / 2f, rectTransform.rect.height / 2f);
            Debug.Log("Top Left Corner: " + topLeft);

            // 获取正方形右下角的坐标（XY坐标）
            Vector2 bottomRight = rectTransform.position + new Vector3(rectTransform.rect.width / 2f, -rectTransform.rect.height / 2f);
            Debug.Log("Bottom Right Corner: " + bottomRight);
        }
        else
        {
            Debug.LogError("RectTransform component not found on the squareObject.");
        }
    }
}