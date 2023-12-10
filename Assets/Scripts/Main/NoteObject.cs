using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;
    public GameObject hitEffect, goodEffect, PerfectEffect, MissEffect;


    private bool obtained;

    public float Length { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){}/*{
    
         if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                obtained =true;
                gameObject.SetActive(false);
                

                //GameManager.instance.NoteHit();

                if(Mathf.Abs(transform.position.y) > 0.25)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect,transform.position, hitEffect.transform.rotation);
                }else if(Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect,transform.position, goodEffect.transform.rotation);
                }else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(PerfectEffect,transform.position, PerfectEffect.transform.rotation);
                }
            }
        }
    }*/
    
}

