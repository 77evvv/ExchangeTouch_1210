using UnityEngine;

namespace PathCreation.Examples
{
    public class PathPercent : MonoBehaviour
    {
        public PathCreator 本地音符路徑;
        [Range(0,1)]
        public float 進度;
        public float pathSpeed;
        public EndOfPathInstruction endOfPathInstruction;
        public float pathOverTime;
        float distanceTravelled;
        
        
        // Start is called before the first frame update
        void Start()
        {
            pathSpeed = 本地音符路徑.path.length / pathOverTime;
            進度 = 0;
        }

        // Update is called once per frame
        void Update()
        {
            /*
            if (distanceTravelled >=本地音符路徑.path.length )
            {
                distanceTravelled = 本地音符路徑.path.length;
            }
            else
            {
                distanceTravelled += pathSpeed * Time.deltaTime;
            }
            
           
            transform.position = 本地音符路徑.path.GetPointAtDistance(distanceTravelled,endOfPathInstruction );
            進度 = distanceTravelled / 本地音符路徑.path.length;
            */
            transform.position = 本地音符路徑.path.GetPointAtDistance(進度 *本地音符路徑.path.length,endOfPathInstruction );
        }
    }
}


