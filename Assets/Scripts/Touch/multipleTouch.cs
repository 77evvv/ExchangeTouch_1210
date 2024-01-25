using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class multipleTouch : MonoBehaviour
{
    public GameObject circle;

    public List<touchLocation> touches = new List<touchLocation>();

    public Text DebugEnd;
    public Text DebugMove;
    public Text DebugBegan;
    
   

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        while (i <Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                DebugEnd.text ="touch Began";
            }else if (t.phase == TouchPhase.Ended)
            {
                DebugMove.text = "touch ended";
            }else if (t.phase == TouchPhase.Moved)
            {
                DebugBegan.text = "touch moving";
            }
        }

        ++i;
    }
}
