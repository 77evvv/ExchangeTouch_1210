using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mgr1 : MonoBehaviour
{
    public Button Abtn;
    public Button Bbtn;
    public Button Cbtn;
    public Button Dbtn;

    public ParticleSystem ps;
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public ParticleSystem ps3;
   
    
    // Start is called before the first frame update
    void Start()
    {
        //ps.transform.position.x = -7.47f;
        ps.Stop();
        ps1.Stop();
        ps2.Stop();
        ps3.Stop();
        Abtn.onClick.AddListener(pPlay);
        Bbtn.onClick.AddListener(pPlay1);
        Cbtn.onClick.AddListener(pPlay2);
        Dbtn.onClick.AddListener(pPlay3);
    }

    void pPlay()
    {
        ps.Play();
       
    }

    void pPlay1()
    {
        ps1.Play();
    }
    void pPlay2()
    {
        ps2.Play();
    }
    void pPlay3()
    {
        ps3.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
