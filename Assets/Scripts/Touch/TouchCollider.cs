using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCollider : MonoBehaviour
{
    public CircleCollider2D cc;
    //此程式是用射線來抓取觸控到的點有無反應(無使用)1208
    public GameObject findObject()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.1f, Vector2.up, Mathf.Infinity);
           if (hit != false)
            {
                if (hit.collider.gameObject.layer == 5)
                {
                    //Debug.Log("find target" + hit.collider.gameObject.name);
                    transform.position = new Vector3(999, 999, 100);
                    return hit.collider.gameObject;
                }
            }
        
        
           transform.position = new Vector3(999, 999, 100);
        return null;

    }
}
