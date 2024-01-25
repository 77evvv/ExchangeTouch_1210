using UnityEngine;

public class parseIDToNote : MonoBehaviour
{
    public HitObject target;

    public int id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void parseFinger(int fingerID)
    {
        id = fingerID;
        target.touchID = fingerID;
    }
}
