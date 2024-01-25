using UnityEngine;

namespace PathCreation.Examples
{
    
    [ExecuteInEditMode]
    public class CustomPathPlacer : MonoBehaviour
    {
        public enum MyEnum
        {
            none,reset
        }

        
        
        public MyEnum enumState;
        public bool closedLoop = false;
        public Transform[] waypoints;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (enumState == MyEnum.reset)
            {
                enumState = MyEnum.none;
                resetPath();
            }
        }

        public void resetPath()
        {
            
            // Create a new bezier path from the waypoints.
            BezierPath bezierPath = new BezierPath (waypoints, closedLoop, PathSpace.xyz);
            GetComponent<PathCreator> ().bezierPath = bezierPath;
            
        }
    }
}

