using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = new Vector3(5.08f, -2.93f,0f);
        transform.DOLocalMove(position, 2.0f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
    

        // Update is called once per frame
    void Update()
    {
        
    }
}
