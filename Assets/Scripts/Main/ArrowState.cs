using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowState : MonoBehaviour

{
    public Text dir;
    public enum dirState
    
    {
        left,right,up,down
    }
    public dirState DS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void dieArrow(Vector3 newDir)
    {
        if(newDir == Vector3.left && DS == dirState.left)
        {
            dir.text = gameObject.tag;
            Destroy(this.gameObject);
            
        }
        else if(newDir == Vector3.right && DS == dirState.right)
        {
            Destroy(this.gameObject);
        }
    }
}
