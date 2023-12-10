using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    public List<int> gameHit= new List<int>();
    public int totalscore;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        totalscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showScore(int aa)
    {
        switch (aa)
        {
            case 0:
            //bad
                aa = 1;
                break;
            case 1:
                //nice
                aa = 5;
                break;
            case 2:
                //perfect
                aa = 100;
                break;
            
        }

        totalscore += aa;
        scoreText.text = totalscore.ToString();

    }
    public void CountScore()
    {
        totalscore = 0;
        foreach(int noteNow in gameHit)
        {
            switch(noteNow)
            {
                case 0:
                break;
                case 1:
                    totalscore += 100;
                break;
                case 2:
                    totalscore += 200;
                break;
                case 3:
                    totalscore += 300;
                break;
            }
        }
    }
}
